namespace KSProject.Models
{
    public abstract record BasicResource;
    public class Resource<T>(T data) where T : BasicResource;
}
