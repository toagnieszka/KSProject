namespace KSProject.Patterns.CQRS.Commands
{
    public interface ICommandHandler<in T>
    {
        public Task Handle(T command);
    }
}
