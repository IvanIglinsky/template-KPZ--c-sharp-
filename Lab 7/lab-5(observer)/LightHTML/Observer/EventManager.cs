using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab_5.LightHTML.Observer
{
    public enum EventType
    {
        OnClick,
        OnFocus,
    }
    public class EventManager
    {
        public List<KeyValuePair<EventType, EventHandler<NodeEventArgs>>> listeners = new();
        public LightNode Node { get; set; }
        public EventManager(LightNode node)
        {
            Node = node;
        }

        public void Subscribe(EventType eventType, EventHandler<NodeEventArgs> listener)
        {
            listeners.Add(new KeyValuePair<EventType, EventHandler<NodeEventArgs>>(eventType, listener));
        }
        public void Unsubscribe(EventHandler<NodeEventArgs> listener)
        {
            foreach (var item in listeners)
            {
                if (item.Value == listener)
                {
                    listeners.Remove(item);
                }
            }
        }

        public void Notify(EventType eventType)
        {
            foreach (var item in listeners)
            {
                if (item.Key == eventType)
                {
                    item.Value.Invoke(this, new NodeEventArgs(Node));
                }
            }
        }
    }
}
