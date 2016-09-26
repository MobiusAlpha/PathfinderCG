using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CharacterGen.Common;
using CharacterGen.Data.Common;

namespace CharacterGen.Data.Filestore
{
    public class FilebackedDataStore : IStartable, IStoppable, IConfigurable, IDataStore<ItemData>, IDataStore<ClassData>, IDataStore<RaceData>, IDataStore<FeatData>, IDataStore<FlawData>, IDataStore<TraitData>, IDataStore<SkillData>, IDataStore<SlottedItemData>, IDataStore<WeaponItemData>, IDataStore<ArmorItemData>
    {
        public ComponentConfigResponse Configure(IConfigurationProvider provider)
        {
            throw new NotImplementedException();
        }

        public ComponentStartResponse Start(RuntimeContext context)
        {
            throw new NotImplementedException();
        }

        public ComponentStopResponse Stop(RuntimeContext context)
        {
            throw new NotImplementedException();
        }

        public void Save(ArmorItemData data)
        {
            throw new NotImplementedException();
        }

        public void Save(WeaponItemData data)
        {
            throw new NotImplementedException();
        }

        public void Save(SlottedItemData data)
        {
            throw new NotImplementedException();
        }

        public void Save(SkillData data)
        {
            throw new NotImplementedException();
        }

        public void Save(TraitData data)
        {
            throw new NotImplementedException();
        }

        public void Save(FlawData data)
        {
            throw new NotImplementedException();
        }

        public void Save(FeatData data)
        {
            throw new NotImplementedException();
        }

        public void Save(RaceData data)
        {
            throw new NotImplementedException();
        }

        public void Save(ClassData data)
        {
            throw new NotImplementedException();
        }

        public void Save(ItemData data)
        {
            throw new NotImplementedException();
        }

        IQueryable<ItemData> IDataStore<ItemData>.Data
        {
            get { throw new NotImplementedException(); }
        }

        IQueryable<ClassData> IDataStore<ClassData>.Data
        {
            get { throw new NotImplementedException(); }
        }

        IQueryable<RaceData> IDataStore<RaceData>.Data
        {
            get { throw new NotImplementedException(); }
        }

        IQueryable<FeatData> IDataStore<FeatData>.Data
        {
            get { throw new NotImplementedException(); }
        }

        IQueryable<FlawData> IDataStore<FlawData>.Data
        {
            get { throw new NotImplementedException(); }
        }

        IQueryable<TraitData> IDataStore<TraitData>.Data
        {
            get { throw new NotImplementedException(); }
        }

        IQueryable<SkillData> IDataStore<SkillData>.Data
        {
            get { throw new NotImplementedException(); }
        }

        IQueryable<SlottedItemData> IDataStore<SlottedItemData>.Data
        {
            get { throw new NotImplementedException(); }
        }

        IQueryable<WeaponItemData> IDataStore<WeaponItemData>.Data
        {
            get { throw new NotImplementedException(); }
        }

        IQueryable<ArmorItemData> IDataStore<ArmorItemData>.Data
        {
            get { throw new NotImplementedException(); }
        }
    }
}
