namespace KSProject.Patterns
{
    public interface IConfigurationFor<in T>;
    
    public class StorageConfig(string connString, string container) : IConfigurationFor<StorageRepository>
    {
        public string ConnectionString { get; } = connString;
        public string Container { get; } = container;
    }

    public class CosmosConfig(string connString, string dbase, string container) : IConfigurationFor<CosmosConfig>
    {
        public string ConnectionString { get; } = connString;
        public string Dbase { get; } = dbase;
        public string Container { get; } = container;
    }
}
