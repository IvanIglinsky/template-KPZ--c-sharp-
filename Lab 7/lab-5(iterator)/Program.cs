
using lab_5.LightHTML;
using lab_5.LightHTML.Strategy;


//Console.WriteLine("1. Composite. LightHTML");
var ul = new LightElementNode("ul", NodeType.ElementNode, ClosureType.Even, new() { "class1", "class2" });
var li0 = new LightElementNode("li", NodeType.ElementNode, ClosureType.Even, new() { "class1" });
var span1 = new LightTextNode("span", "Text");
var span2 = new LightTextNode("span", "Text");
var p = new LightTextNode("p", "Paragraph");
var li1 = new LightElementNode("li", NodeType.ElementNode, ClosureType.Even, new() { "class1" });
var li2 = new LightElementNode("li", NodeType.ElementNode, ClosureType.Even, new() { "class1" });
li0.AppendChild(span1);
li0.AppendChild(span2);
ul.AppendChild(li1);
ul.AppendChild(li2);
li1.AppendChild(p);
ul.InsertBefore(li1, li0);
Console.WriteLine(ul.OuterHTML());
Console.WriteLine("Surface iterator:");
ul.Children.Strategy = new SurfaceStrategy();
printDOM();
Console.WriteLine("Depth iterator:");
ul.Children.Strategy = new DepthFirstStrategy();
printDOM();
Console.WriteLine("Breadth iterator:");
ul.Children.Strategy = new BreadthFirstStrategy();
printDOM();
void printDOM()
{
    foreach (var child in ul.Children)
    {
        Console.WriteLine($"{child.Tag}");
    }

}
