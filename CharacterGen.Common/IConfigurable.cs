namespace CharacterGen.Common
{
    public interface IConfigurable
    {
        ComponentConfigResponse Configure(IConfigurationProvider provider);
    }
}