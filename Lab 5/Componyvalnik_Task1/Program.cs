using System.Text;

            Console.WriteLine("\n=== Testing Create table ===");
            var div = new LightElementNode("div",true,true);
            var text = new LightTextNode("Hello, World!");
            div.AppendChild(text);
            // Output outerHTML and innerHTML element
            Console.WriteLine(div.OuterHtml); // <div>Hello, World!</div>
            Console.WriteLine(div.InnerHtml); // Hello, World!
            div.AddClass("container");
            Console.WriteLine(div.OuterHtml);
            div.RemoveClass("container");
            Console.WriteLine(div.OuterHtml); // <div>Hello, World!</div>
            // Create table
            var table = new LightElementNode("table",true,true);
            table.AddClass("table");
            // Create header table
            var thead = new LightElementNode("thead",true,true);
            var trHead = new LightElementNode("tr",true,true);
            var th1 = new LightElementNode("th",true,true);
            var th2 = new LightElementNode("th",true,true);
            var th3 = new LightElementNode("th",true,true);
            th1.AppendChild(new LightTextNode("ID"));
            th2.AppendChild(new LightTextNode("Name"));
            th3.AppendChild(new LightTextNode("Age"));
            trHead.AppendChild(th1);
            trHead.AppendChild(th2);
            trHead.AppendChild(th3);
            thead.AppendChild(trHead);
            table.AppendChild(thead);
            // Building body table
            var tbody = new LightElementNode("tbody",true,true);
            for (int i = 0; i < 3; i++)
            {
                var tr = new LightElementNode("tr",true,true);
                var td1 = new LightElementNode("td",true,true);
                var td2 = new LightElementNode("td",true,true);
                var td3 = new LightElementNode("td",true,true);
                td1.AppendChild(new LightTextNode((i + 1).ToString()));
                td2.AppendChild(new LightTextNode($"User {i + 1}"));
                td3.AppendChild(new LightTextNode((20 + i).ToString()));
                tr.AppendChild(td1);
                tr.AppendChild(td2);
                tr.AppendChild(td3);
                tbody.AppendChild(tr);
            }
            table.AppendChild(tbody);
            Console.WriteLine(table.InnerHtml);
            Console.WriteLine("\n=== Testing LightElementNode ===");

            // Test creation of LightElementNode object

            LightElementNode node = new LightElementNode("div",true,true);
            Console.WriteLine(node);

            // Test appending child nodes
            LightElementNode childNode1 = new LightElementNode("p",true,true);
            LightElementNode childNode2 = new LightElementNode("img",true,true);
            node.AppendChild(childNode1);
            node.AppendChild(childNode2);
            Console.WriteLine(node.InnerHtml);

            // Test replacing child nodes
            LightElementNode newNode = new LightElementNode("h1",true,true);
            node.ReplaceChild(newNode, childNode1);
            Console.WriteLine(node.InnerHtml);

            // Test inserting child nodes before a reference node
            LightElementNode newChildNode = new LightElementNode("span",true,true);
            node.InsertBefore(newChildNode, newNode);
            Console.WriteLine(node.InnerHtml);

            // Test removing child nodes
            node.RemoveChild(newChildNode);
            Console.WriteLine(node.InnerHtml);
            Console.WriteLine("\n=== Testing LightTextNode ===");

            // Test creation of a LightTextNode object
            LightTextNode node1 = new LightTextNode("Hello, world!");
            Console.WriteLine(node1);

            // Test setting and getting text content
            node1.Text = "Goodbye, world!";
            Console.WriteLine(node1.Text);

public abstract class LightNode
    {
        public abstract string OuterHtml { get; }
        public abstract string InnerHtml { get; }
    }
    public class LightTextNode : LightNode
    {
        private string _text;

        public LightTextNode(string text)
        {
            _text = text;
        }

        public string Text
        {
            get { return _text; }
            set { _text = value; }
        }

        public override string OuterHtml
        {
            get { return _text; }
        }

        public override string InnerHtml
        {
            get { return _text; }
        }
    }

    public class LightElementNode : LightNode
    {
        private readonly string _tagName;
        private readonly bool _isBlock;
        private readonly bool _isSelfClosing;
        private readonly List<LightNode> _childNodes = new List<LightNode>();
        private readonly List<string> _classes = new List<string>();

        public LightElementNode(string tagName, bool isBlock, bool isSelfClosing)
        {
            _tagName = tagName;
            _isBlock = isBlock;
            _isSelfClosing = isSelfClosing;
        }

 

        public void AppendChild(LightNode node)
        {
            _childNodes.Add(node);
        }

        public void ReplaceChild(LightNode newChild, LightNode oldChild)
        {
            int index = _childNodes.IndexOf(oldChild);
            if (index != -1)
            {
                _childNodes[index] = newChild;
            }
        }

        public void RemoveChild(LightNode node)
        {
            _childNodes.Remove(node);
        }

        public void InsertBefore(LightNode newNode, LightNode refNode)
        {
            int index = _childNodes.IndexOf(refNode);
            if (index != -1)
            {
                _childNodes.Insert(index, newNode);
            }
        }

        public void AddClass(string className)
        {
            _classes.Add(className);
        }

        public void RemoveClass(string className)
        {
            _classes.Remove(className);
        }

        public override string OuterHtml
        {
            get
            {
                StringBuilder sb = new StringBuilder();
                sb.AppendFormat("<{0}", _tagName);

                if (_classes.Count > 0)
                {
                    sb.AppendFormat("class=\"{0}\"", string.Join(" ", _classes));
                }

                if (_isSelfClosing)
                {
                    sb.Append("/>");
                }
                else
                {
                    sb.Append(">");

                    foreach (LightNode node in _childNodes)
                    {
                        sb.Append(node.OuterHtml);
                    }

                    sb.AppendFormat("</{0}>", _tagName);
                }

                return sb.ToString();
            }
        }

        public override string InnerHtml
        {
            get
            {
                StringBuilder sb = new StringBuilder();

                foreach (LightNode node in _childNodes)
                {
                    sb.Append(node.OuterHtml);
                }

                return sb.ToString();
            }
        }
    }