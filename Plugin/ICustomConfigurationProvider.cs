using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plugin
{
    public interface ICustomConfigurationProvider
    {
        ConfigurationProviderType ConfigurationProviderType { get; }

        string Read(string key);

        void Write<TInput>(string key, TInput value);
    }
}
