namespace KSProject.Patterns.Repository
{
	public interface IRepository
	{
		public Task<T> Get<T>(Guid Id) where T : class, IRepositoryObject;
		public Task Save<T>(T input) where T : class, IRepositoryObject;
	}
}
