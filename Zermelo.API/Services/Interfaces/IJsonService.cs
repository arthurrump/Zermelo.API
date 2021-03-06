﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zermelo.API.Services.Interfaces
{
    internal interface IJsonService
    {
        IEnumerable<T> DeserializeCollection<T>(string json);
        T GetValue<T>(string json, string key);
    }
}
