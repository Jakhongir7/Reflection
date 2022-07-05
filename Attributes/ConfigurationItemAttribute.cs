using Plugin;
using System;

namespace Attributes
{
    [AttributeUsage(AttributeTargets.Property)]
    public sealed class ConfigurationItemAttribute : Attribute
    {
        private readonly string _settingName;
        private readonly ConfigurationProviderType _configurationProviderType;

        public ConfigurationItemAttribute(string settingName,
            ConfigurationProviderType configurationProviderType)
        {
            _settingName = settingName;
            _configurationProviderType = configurationProviderType;
        }

        public string SettingName => _settingName;

        public ConfigurationProviderType ConfigurationProviderType => _configurationProviderType;
    }
}
