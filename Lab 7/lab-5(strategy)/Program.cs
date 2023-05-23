
using lab_5.LightHTML.Strategy;


internal class Program
{
    private static async Task Main(string[] args)
    {
        var img = new ImageNode("https://i0.wp.com/ourgenerationmusic.com/wp-content/uploads/2023/01/img_9375.jpg");
        await img.LoadImage();
        Console.WriteLine(img.OuterHTML());
       
    }
}
