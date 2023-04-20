
using System.Text;

var fileText = File.ReadAllLines("book.txt");

long totalSize = 0;
foreach (string line in fileText)
{
    if (line.Length < 20)
    {    string html = "<h2>" + line + "</h2>";
        totalSize += sizeof(char) * html.Length;
        Console.WriteLine(html);
  
    }
    else if (line.StartsWith(" "))
    {
        string html = "<blockquote>" + line + "</blockquote>";
        totalSize += sizeof(char) * html.Length;
        Console.WriteLine(html);
       
    }
    else
    {
        string html = "<p>" + line + "</p>";
        totalSize += sizeof(char) * html.Length;
        Console.WriteLine(html);
    }
}
Console.WriteLine("Total size: " + totalSize);

Console.WriteLine("\n\nLightWeight\n\n");

long totalSize1 = 0;
StringBuilder sb = new StringBuilder();

foreach (string line in fileText)
{
    HtmlElement elem = null;

    if (line.Length < 20)
    {
        elem = new HtmlHeadingElement("h2", line);
        totalSize1 += sizeof(char) * elem.Lenght();
    }
    else if (line.StartsWith(" "))
    {
        elem = new HtmlElement("blockquote", line);
        totalSize1 += sizeof(char) * elem.Lenght();
    }
    else
    {
        elem = new HtmlParagraphElement(line);
        totalSize1 += sizeof(char) * elem.Lenght();
    }

    sb.Append(elem.ToString());
}

string bookHtml = sb.ToString();
Console.WriteLine(bookHtml);
Console.WriteLine("Total size: " + totalSize1);
public class HtmlElement
{
    protected string tag;
    protected string text;

    public HtmlElement(string tag, string text)
    {
        this.tag = tag;
        this.text = text;
    }

    public override string ToString()
    {
        return string.Format("<{0}>{1}</{0}>", tag, text);
    }

    public long Lenght()
    {
        return this.text.Length;
    }
}

public class HtmlHeadingElement : HtmlElement
{
    public HtmlHeadingElement(string tag, string text)
        : base(tag, text)
    {

    }
}

public class HtmlParagraphElement : HtmlElement
{
    public HtmlParagraphElement(string text)
        : base("p", text)
    {

    }
}