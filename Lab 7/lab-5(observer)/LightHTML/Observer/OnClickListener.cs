using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab_5.LightHTML.Observer
{
    public class OnClickListener : IEventListener
    {
        public event EventHandler<NodeEventArgs> Handler;
        public OnClickListener(EventHandler<NodeEventArgs> eventHandler)
        {
            Handler = eventHandler;
        }
        public void Update(LightNode node)
        {
            Handler.Invoke(this, new NodeEventArgs(node));
        }
    }
}
