using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab_5.LightHTML.Observer
{
    public class NodeEventArgs : EventArgs
    {
        public LightNode Node { get; private set; }
        public NodeEventArgs(LightNode node)
        {
            Node = node;
        }
    }
}
