using lab_5.LightHTML.Iterator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab_5.LightHTML
{
    public enum NodeType
    {
        TextNode,
        ElementNode
    }
    public enum ClosureType
    {
        Single,
        Even
    }
    abstract public class LightNode
    {
        public NodesCollection Children = new NodesCollection();
        public string Tag { get; set; }
        abstract public string InnerHTML();
        abstract public string OuterHTML();
        abstract public LightNode Clone();
    }
}
