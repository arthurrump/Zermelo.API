// Copyright(c) Microsoft Corporation
// 
// 
// Permission is hereby granted, free of charge, to any person obtaining a copy 
// of this software and associated documentation files (the "Software"), to deal 
// in the Software without restriction, including without limitation the rights 
// to use, copy, modify, merge, publish, distribute, sublicense, and/or sell 
// copies of the Software, and to permit persons to whom the Software is 
// furnished to do so, subject to the following conditions: 
// 
// 
// The above copyright notice and this permission notice shall be included in all 
// copies or substantial portions of the Software. 
// 
// 
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR 
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, 
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE 
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER 
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, 
// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE 
// SOFTWARE. 

using System;

namespace Zermelo.API.Helpers
{
    internal static class UnixTimeHelpers
    {
        // Number of 100ns ticks per time unit 
        private const long TicksPerMillisecond = 10000;
        private const long TicksPerSecond = TicksPerMillisecond * 1000;
        private const long TicksPerMinute = TicksPerSecond * 60;
        private const long TicksPerHour = TicksPerMinute * 60;
        private const long TicksPerDay = TicksPerHour * 24;


        // Number of days in a non-leap year 
        private const int DaysPerYear = 365;
        // Number of days in 4 years 
        private const int DaysPer4Years = DaysPerYear * 4 + 1;       // 1461 
        // Number of days in 100 years 
        private const int DaysPer100Years = DaysPer4Years * 25 - 1;  // 36524 
        // Number of days in 400 years 
        private const int DaysPer400Years = DaysPer100Years * 4 + 1; // 146097 

        // Number of days from 1/1/0001 to 12/31/1600 
        private const int DaysTo1601 = DaysPer400Years * 4;          // 584388 
        // Number of days from 1/1/0001 to 12/30/1899 
        private const int DaysTo1899 = DaysPer400Years * 4 + DaysPer100Years * 3 - 367;
        // Number of days from 1/1/0001 to 12/31/1969 
        internal const int DaysTo1970 = DaysPer400Years * 4 + DaysPer100Years * 3 + DaysPer4Years * 17 + DaysPerYear; // 719,162 
        // Number of days from 1/1/0001 to 12/31/9999 
        private const int DaysTo10000 = DaysPer400Years * 25 - 366;  // 3652059 

        internal const long MinTicks = 0;
        internal const long MaxTicks = DaysTo10000 * TicksPerDay - 1;


        private const long UnixEpochTicks = TimeSpan.TicksPerDay * DaysTo1970; // 621,355,968,000,000,000 
        private const long UnixEpochSeconds = UnixEpochTicks / TimeSpan.TicksPerSecond; // 62,135,596,800 
        private const long UnixEpochMilliseconds = UnixEpochTicks / TimeSpan.TicksPerMillisecond; // 62,135,596,800,000 

        internal const long UnixMinSeconds = MinTicks / TimeSpan.TicksPerSecond - UnixEpochSeconds;
        internal const long UnixMaxSeconds = MaxTicks / TimeSpan.TicksPerSecond - UnixEpochSeconds;


        public static DateTimeOffset FromUnixTimeSeconds(long seconds)
        {
            if (seconds < UnixMinSeconds || seconds > UnixMaxSeconds)
            {
                throw new ArgumentOutOfRangeException(nameof(seconds), $"Min: {UnixMinSeconds}, Max: {UnixMaxSeconds}");
            }


            long ticks = seconds * TimeSpan.TicksPerSecond + UnixEpochTicks;
            return new DateTimeOffset(ticks, TimeSpan.Zero);
        }

        public static DateTimeOffset FromUnixTimeMilliseconds(long milliseconds)
        {
            const long MinMilliseconds = MinTicks / TimeSpan.TicksPerMillisecond - UnixEpochMilliseconds;
            const long MaxMilliseconds = MaxTicks / TimeSpan.TicksPerMillisecond - UnixEpochMilliseconds;


            if (milliseconds < MinMilliseconds || milliseconds > MaxMilliseconds)
            {
                throw new ArgumentOutOfRangeException(nameof(milliseconds), $"Min: {MinMilliseconds}, Max: {MaxMilliseconds}");
            }


            long ticks = milliseconds * TimeSpan.TicksPerMillisecond + UnixEpochTicks;
            return new DateTimeOffset(ticks, TimeSpan.Zero);
        }

        public static long ToUnixTimeSeconds(DateTimeOffset date)
        {
            // Truncate sub-second precision before offsetting by the Unix Epoch to avoid 
            // the last digit being off by one for dates that result in negative Unix times. 
            // 
            // For example, consider the DateTimeOffset 12/31/1969 12:59:59.001 +0 
            //   ticks            = 621355967990010000 
            //   ticksFromEpoch   = ticks - UnixEpochTicks                   = -9990000 
            //   secondsFromEpoch = ticksFromEpoch / TimeSpan.TicksPerSecond = 0 
            // 
            // Notice that secondsFromEpoch is rounded *up* by the truncation induced by integer division, 
            // whereas we actually always want to round *down* when converting to Unix time. This happens 
            // automatically for positive Unix time values. Now the example becomes: 
            //   seconds          = ticks / TimeSpan.TicksPerSecond = 62135596799 
            //   secondsFromEpoch = seconds - UnixEpochSeconds      = -1 
            // 
            // In other words, we want to consistently round toward the time 1/1/0001 00:00:00, 
            // rather than toward the Unix Epoch (1/1/1970 00:00:00).
            long seconds = date.UtcDateTime.Ticks / TimeSpan.TicksPerSecond;
            return seconds - UnixEpochSeconds;
        }

        public static long ToUnixTimeMilliseconds(DateTimeOffset date)
        {
            // Truncate sub-millisecond precision before offsetting by the Unix Epoch to avoid 
            // the last digit being off by one for dates that result in negative Unix times 
            long milliseconds = date.UtcDateTime.Ticks / TimeSpan.TicksPerMillisecond;
            return milliseconds - UnixEpochMilliseconds;
        }
    }
}
