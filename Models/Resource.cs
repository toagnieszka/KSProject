namespace KSProject.Models
{
    public abstract record BasicResource;
    public class Resource<T>(T data) where T : BasicResource;




    public record struct Slot(DateTime Start, DateTime End);
    public record Appointment(Guid Id, Slot Slot, Person Patient) : BasicResource;
    public record Visit(Guid Id, Slot Slot, Person Patient) : BasicResource;
}
