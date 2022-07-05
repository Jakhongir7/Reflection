using Attributes;
using Plugin;
using System;
using System.Collections.Generic;

namespace Attributes.Components
{
    public abstract class ConfigurationComponentBase
    {
        private readonly IDictionary<ConfigurationProviderType, ICustomConfigurationProvider> _providers;

        public ConfigurationComponentBase()
        {
            _providers = ProvidersLoader.GetProviders();
        }

        public virtual int Count
        {
            get => LoadSetting<int>(nameof(Count));
            set => SaveSettings(nameof(Count), value);
        }

        public virtual string Name
        {
            get => GetStringValue(nameof(Name));
            set => SaveSettings(nameof(Name), value);
        }

        public virtual float Rate
        {
            get => LoadSetting<float>(nameof(Rate));
            set => SaveSettings(nameof(Rate), value);
        }

        public virtual TimeSpan Duration
        {
            get => LoadSetting<TimeSpan>(nameof(Duration));
            set => SaveSettings(nameof(Duration), value);
        }

        protected T LoadSetting<T>(string settingName)
        {
            var attribute = GetAttribute(settingName);
            if (attribute != null)
            {
                var provider = _providers[attribute.ConfigurationProviderType];
                return Parser.TryParse(provider.Read(settingName), out T result) ? result : default;
            }
            return default;
        }

        protected void SaveSettings<T>(string settingName, T value)
        {
            var attribute = GetAttribute(settingName);
            if (attribute != null)
            {
                var provider = _providers[attribute.ConfigurationProviderType];
                provider.Write(settingName, value);
            }
        }

        protected string GetStringValue(string settingName)
        {
            var attribute = GetAttribute(settingName);
            if (attribute != null)
            {
                var provider = _providers[attribute.ConfigurationProviderType];
                return provider.Read(settingName);
            }

            return string.Empty;
        }

        private ConfigurationItemAttribute GetAttribute(string settingName)
        {
            var type = GetType();
            var property = type.GetProperty(settingName);
            return property != null ? (ConfigurationItemAttribute)Attribute.GetCustomAttribute(property,
                    typeof(ConfigurationItemAttribute)) : null;
        }
    }
}
