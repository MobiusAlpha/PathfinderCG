using System.Linq;

namespace CharacterGen.Data.Common
{
    public interface IDataStore<T>
    {
        IQueryable<T> Data { get; }
        void Save(T data);
    }
}