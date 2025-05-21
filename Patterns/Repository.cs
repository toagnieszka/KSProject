namespace KSProject.Patterns
{
    public interface IRepositoryObject;
    public interface IRepository
    {
        public Task<T> Get<T>(Guid Id) where T : class, IRepositoryObject;
        public Task Save<T>(T input) where T : class, IRepositoryObject;
    }
    public class StorageRepository(string connString, string container) : IRepository
    {
        Task<T> IRepository.Get<T>(Guid Id)
        {
			throw new NotImplementedException();
		}

        Task IRepository.Save<T>(T input)
        {
            throw new NotImplementedException();
        }
    }

    public class CosmosRepository(string connString, string dbase, string container) : IRepository
    {
        Task<T> IRepository.Get<T>(Guid Id)
        {
            throw new NotImplementedException();
        }

        Task IRepository.Save<T>(T input)
        {
            throw new NotImplementedException();
        }
    }
}
