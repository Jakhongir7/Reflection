using Attributes.Components;
using System;

namespace Reflection
{
    class Program
    {
        static void Main(string[] args)
        {
            var settings = new FileSettings();

            DemonstrateInfo(settings);
            settings.Name = "Value";
            settings.Duration = TimeSpan.FromSeconds(500);
            settings.Rate = (float)7.5;
            settings.Count = 5;
            DemonstrateInfo(settings);
        }

        static void DemonstrateInfo(ConfigurationComponentBase settings)
        {
            Console.WriteLine("Name: {0}", settings.Name);
            Console.WriteLine("Duration: {0}", settings.Duration);
            Console.WriteLine("Rate: {0}", settings.Rate);
            Console.WriteLine("Count: {0}", settings.Count);
        }
    }
}
