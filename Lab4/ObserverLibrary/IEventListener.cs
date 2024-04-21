

namespace ObserverLibrary
{
    public interface IEventListener
    {
        void HandleEvent(string eventType, LightNode source);
    }
}
