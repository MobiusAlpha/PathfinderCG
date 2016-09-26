using System.Collections.Generic;

namespace CharacterGen.Common
{
    public interface IConfigurationProvider
    {
        T Get<T>(string key);
        void Set<T>(string key, T value);

        IDictionary<string,object> Registry { get; }

        string MachineName { get; }
        string ApplicationName { get; }
        string Environment { get; }
        string Version { get; }
    }
}