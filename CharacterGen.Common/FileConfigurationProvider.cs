using System.Collections.Generic;

namespace CharacterGen.Common
{
    public class FileConfigurationProvider : IConfigurationProvider
    {
        public T Get<T>(string key)
        {
            throw new System.NotImplementedException();
        }

        public void Set<T>(string key, T value)
        {
            throw new System.NotImplementedException();
        }

        public IDictionary<string, object> Registry { get; }
        public string MachineName { get; }
        public string ApplicationName { get; }
        public string Environment { get; }
        public string Version { get; }
    }
}