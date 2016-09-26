namespace CharacterGen.Common
{
    public interface IStoppable
    {
        ComponentStopResponse Stop(RuntimeContext context);
    }
}