namespace KSProject.Patterns.CQRS.Queries
{
    public interface IQueryHandler<in TQuery, TResult>
    {
        public Task<TResult> Handle(TQuery query);
    }
}
