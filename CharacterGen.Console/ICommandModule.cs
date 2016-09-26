using System.Collections.Concurrent;

namespace CharacterGen.ConsoleApp
{
    public interface ICommandModule
    {
        BlockingCollection<string> InputStream { get; }
        BlockingCollection<string> OutputStream { get; }
    }
}