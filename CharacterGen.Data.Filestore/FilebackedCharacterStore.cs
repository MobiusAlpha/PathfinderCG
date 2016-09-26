using System;
using System.Linq;
using CharacterGen.Common;
using CharacterGen.Data.Common;

namespace CharacterGen.Data.Filestore
{
    public class FilebackedCharacterStore : IStartable, IStoppable, IConfigurable, IDataStore<CharacterData>
    {
        public ComponentStartResponse Start(RuntimeContext context)
        {
            throw new NotImplementedException();
        }

        public ComponentStopResponse Stop(RuntimeContext context)
        {
            throw new NotImplementedException();
        }

        public ComponentConfigResponse Configure(IConfigurationProvider provider)
        {
            throw new NotImplementedException();
        }

        public IQueryable<CharacterData> Data { get; }
        public void Save(CharacterData data)
        {
            throw new NotImplementedException();
        }
    }
}