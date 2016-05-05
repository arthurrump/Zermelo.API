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
        public ObservableCollection<T> DeserializeCollection<T>(string json)
        {
            JObject jsonResult = JObject.Parse(json);
            IEnumerable<JToken> jsonResults = jsonResult["response"]["data"].Children();

            ObservableCollection<T> collection = new ObservableCollection<T>();
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
