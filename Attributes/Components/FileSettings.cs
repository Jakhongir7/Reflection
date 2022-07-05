using Plugin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Attributes.Components
{
    public class FileSettings : ConfigurationComponentBase
    {
        public const ConfigurationProviderType ProviderType = ConfigurationProviderType.File;

        [ConfigurationItem(nameof(Count), ProviderType)]
        public override int Count { get => base.Count; set => base.Count = value; }

        [ConfigurationItem(nameof(Name), ProviderType)]
        public override string Name { get => base.Name; set => base.Name = value; }

        [ConfigurationItem(nameof(Rate), ProviderType)]
        public override float Rate { get => base.Rate; set => base.Rate = value; }

        [ConfigurationItem(nameof(Duration), ProviderType)]
        public override TimeSpan Duration { get => base.Duration; set => base.Duration = value; }
    }
}
