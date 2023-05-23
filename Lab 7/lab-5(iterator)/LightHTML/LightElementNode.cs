using lab_5.LightHTML.Iterator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab_5.LightHTML
{
    public class LightElementNode : LightNode
    {
        public NodeType NodeType { get; }
        public ClosureType ClosureType { get; }
        public List<string> CssClasses { get; set; }
        public int ChildCount => 0;
        public LightElementNode(string tag, NodeType nodeType, ClosureType closureType, List<string> cssClasses)
        {
            Tag = tag;
            NodeType = nodeType;
            ClosureType = closureType;
            CssClasses = cssClasses;
        }

        public override string OuterHTML()
        {
            StringBuilder sb = new StringBuilder($"<{Tag} ");
            sb.Append($"classes=\"");
            foreach (var c in CssClasses)
            {
                sb.Append($"{c} ");
            }
            sb.Append("\"");
            if (ClosureType == ClosureType.Single)
            {
                sb.Append("/>");
            }
            else
            {
                if (Children.GetItems().Count > 0)
                {
                    sb.AppendLine(">");
                }
                else
                {
                    sb.Append(">");
                }
                sb.Append(InnerHTML());
                sb.Append($"</{Tag}>");

            }
            return sb.ToString();
        }
        public override string InnerHTML()
        {

            StringBuilder sb = new StringBuilder();

            foreach (var c in Children)
            {
                sb.AppendLine($"\t{c.OuterHTML()}");
            }
            return sb.ToString();
        }
        public void AppendChild(LightNode node)
        {
            Children.AddItem(node);
        }
        public void ReplaceChild(LightNode oldNode, LightNode newNode)
        {
            var index = Children.GetItems().IndexOf(oldNode);
            if (index != -1)
            {
                Children.GetItems()[index] = newNode;
            }
        }
        public void RemoveChild(LightNode node)
        {
            var index = Children.GetItems().IndexOf(node);
            if (index != -1)
            {
                Children.GetItems().RemoveAt(index);
            }
        }
        public void InsertBefore(LightNode node, LightNode newNode)
        {
            var index = Children.GetItems().IndexOf(node);
            if (index != -1)
            {
                Children.GetItems().Insert(index, newNode);
            }
        }
        public override LightNode Clone()
        {
            var clone = new LightElementNode(Tag, NodeType, ClosureType, new(CssClasses));
            foreach (var c in Children)
            {
                clone.Children.AddItem(c.Clone());
            }
            return clone;
        }
    }
}
