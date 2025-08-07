using KSProject.Patterns.Configuration;
using KSProject.Patterns.Repository;

namespace KSProject.Patterns
{
	public static class Factory
	{
		public static T Create<T>(IConfigurationFor<T> config) where T : class, IRepository
		{
			switch (config)
			{
				case StorageConfig storageConfig:
					return new StorageRepository(storageConfig.ConnectionString, storageConfig.Container) as T;
				case CosmosConfig cosmosConfig:
					return new CosmosRepository(cosmosConfig.ConnectionString, cosmosConfig.Dbase, cosmosConfig.Container) as T;
			}
			return null;
		}
	}
}
