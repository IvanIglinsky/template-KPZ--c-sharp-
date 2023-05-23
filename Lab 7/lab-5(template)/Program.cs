

using lab_5.LightHTML;


Console.WriteLine("1. Composite. LightHTML");
var ul = new LightElementNode("ul", NodeType.ElementNode, ClosureType.Even, new() { "class1", "class2" });
var li0 = new LightTextNode("li", "li0");

ul.AppendChild(li0);
Console.WriteLine(ul.OuterHTML());
