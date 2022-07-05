using Newtonsoft.Json;
using Plugin;
using System;
using System.IO;

namespace Providers
{
    public class ConfigurationManagerProvider : ICustomConfigurationProvider
    {
        private readonly string _filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "appsettings.json");

        public ConfigurationProviderType ConfigurationProviderType => ConfigurationProviderType.ConfigurationManager;

        public string Read(string key)
        {
            var inputJson = File.ReadAllText(_filePath);
            dynamic jsonObject = JsonConvert.DeserializeObject(inputJson);

            return jsonObject[key];
        }

        public void Write<TInput>(string key, TInput value)
        {
            var inputJson = File.ReadAllText(_filePath);

            dynamic jsonObject = JsonConvert.DeserializeObject(inputJson);
            jsonObject[key] = value;

            var outputJson = JsonConvert.SerializeObject(jsonObject, Formatting.Indented);
            File.WriteAllText(_filePath, outputJson);
        }
    }
}
