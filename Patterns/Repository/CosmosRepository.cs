namespace KSProject.Patterns.Repository
{
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
