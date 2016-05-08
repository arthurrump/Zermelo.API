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
            IEnumerable<JToken> jsonResults = jsonResult["response"]["data"].Children();

            List<T> collection = new List<T>();
            foreach (JToken t in jsonResults)
            {
                collection.Add(JsonConvert.DeserializeObject<T>(t.ToString()));
            }

            return collection;
        }

        public T GetValue<T>(string json, string key)
        {
            return JObject.Parse(json).Value<T>(key);
        }
    }
}
