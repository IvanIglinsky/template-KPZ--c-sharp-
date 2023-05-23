using lab_5.LightHTML.Observer;
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
        public string Tag { get; set; }
        public EventManager Events { get; set; }
      
        abstract public string InnerHTML();
        abstract public string OuterHTML();
        abstract public LightNode Clone();
        public void InvokeClick()
        {
            Events.Notify(EventType.OnClick);
        }
        public void InvokeOnFocus()
        {
            Events.Notify(EventType.OnFocus);
        }
    }
}
