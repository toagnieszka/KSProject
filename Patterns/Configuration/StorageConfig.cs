using KSProject.Patterns.Repository;

namespace KSProject.Patterns.Configuration
{
	public class StorageConfig(string connString, string container) : IConfigurationFor<StorageRepository>
	{
		public string ConnectionString { get; } = connString;
		public string Container { get; } = container;
	}
}
