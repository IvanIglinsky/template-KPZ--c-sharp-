
var Adapter = new Adapter();
Adapter.Log();
Adapter.WriteLine("1234");
Adapter.Error();
Adapter.Write("5678");
Adapter.Warn();
Adapter.Write("910");

class  Logger
{
    public void Log()
    {
        Console.ForegroundColor = ConsoleColor.Green;
      
    }

    public void Error()
    {
        Console.ForegroundColor = ConsoleColor.Yellow;
 
    }

    public void Warn()
    {
        Console.ForegroundColor = ConsoleColor.Red;
     
    }
}

class FileWriter:Logger
{
    public void Write(string text)
    {
        Console.Write(text);
    }

    public void WriteLine(string text)
    {
        Console.WriteLine(text);
    }
}

class Adapter : FileWriter
{
   
}