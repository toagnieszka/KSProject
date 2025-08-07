using Microsoft.Extensions.Logging;

namespace KSProject.Patterns.Observer
{
    public abstract class Subscriber
    {
        public abstract void OnEventRaised(object sender, EventArgs args);

        public void Subscribe(Publisher publisher)
        {
            publisher.Handler += OnEventRaised;
        }
        public abstract void Unsubscribe(Publisher publisher);
    }
}
