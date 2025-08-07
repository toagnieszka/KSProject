using KSProject.Patterns.Repository;

namespace KSProject.Patterns.Configuration
{
    public class CosmosConfig(string connString, string dbase, string container) : IConfigurationFor<CosmosConfig>
    {
        public string ConnectionString { get; } = connString;
        public string Dbase { get; } = dbase;
        public string Container { get; } = container;
    }
}
