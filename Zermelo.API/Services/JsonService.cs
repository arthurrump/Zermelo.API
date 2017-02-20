using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zermelo.API.Services.Interfaces;

namespace Zermelo.API.Services
{
    internal class JsonService : IJsonService
    {
        public IEnumerable<T> DeserializeCollection<T>(string json)
        {
            JObject jsonResult = JObject.Parse(json);

            return jsonResult["response"]["data"].Children()
                .Select(token => JsonConvert.DeserializeObject<T>(token.ToString()));
        }

        public T GetValue<T>(string json, string key)
        {
            return JObject.Parse(json).Value<T>(key);
        }
    }
}
