
using lab_5.LightHTML;
using lab_5.LightHTML.Observer;

Console.WriteLine("1. Composite. LightHTML");
var ul = new LightElementNode("ul", NodeType.ElementNode, ClosureType.Even, new() { "class1", "class2" });
var li0 = new LightTextNode("li", "li0");
var li1 = new LightTextNode("li", "li1");
var li2 = new LightTextNode("li", "li2");
ul.AppendChild(li1);
ul.AppendChild(li2);
ul.InsertBefore(li1, li0);
LightElementNode ulClone = (LightElementNode)ul.Clone();
Console.WriteLine(ulClone.OuterHTML());

li0.Events.Subscribe(EventType.OnClick, (sender, args) =>
{
    Console.WriteLine($"{args.Node.OuterHTML()} Clicked");
});
li0.Events.Subscribe(EventType.OnClick, (sender, args) =>
{
    Console.WriteLine($"{args.Node.OuterHTML()} Clicked (2nd listener)");
});
li1.Events.Subscribe(EventType.OnFocus, (sender, args) =>
{
    Console.WriteLine($"{args.Node.OuterHTML()} Focused");
});
li0.InvokeClick();
li1.InvokeOnFocus();
