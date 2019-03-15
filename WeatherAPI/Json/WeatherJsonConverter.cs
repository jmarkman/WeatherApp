using System;
using System.Reflection;
using System.Text.RegularExpressions;
using System.Linq;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace WeatherAPI.Json
{
    public class WeatherJsonConverter : JsonConverter
    {
        public override bool CanWrite
        {
            get { return false; }
        }

        public override bool CanConvert(Type objectType)
        {
            return objectType.IsClass;
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            object instance = objectType.GetConstructor(Type.EmptyTypes).Invoke(null);
            PropertyInfo[] properties = objectType.GetProperties();

            JObject jsonObj = JObject.Load(reader);
            foreach (var jsonProp in jsonObj.Properties())
            {
                var name = Regex.Replace(jsonProp.Name, "[^A-Za-z0-9]+", "");
                PropertyInfo propInfo = properties.FirstOrDefault(pi => pi.CanWrite && string.Equals(pi.Name, name, StringComparison.OrdinalIgnoreCase));
                if (propInfo != null)
                {
                    propInfo.SetValue(instance, jsonProp.Value.ToObject(propInfo.PropertyType, serializer));
                }
            }

            return instance;
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
    }
}
