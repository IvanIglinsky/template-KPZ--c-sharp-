using System.Text.RegularExpressions;

    //SmartTextReader:
    char[][] textArray = SmartTextReader.ReadFile("test.txt");
    if (textArray != null)
    {
        Console.WriteLine($"Read {textArray.Length} lines and {textArray[0].Length} characters.");
    }
    // SmartTextChecker:
    char[][] checkedTextArray = SmartTextChecker.ReadFile("test.txt");

    //SmartTextReaderLocker:
    SmartTextReaderLocker reader = new SmartTextReaderLocker("restricted_.*");
    char[][] restrictedTextArray = reader.ReadFile("restricted_file.txt");
  

class SmartTextReader
{
    public static char[][] ReadFile(string filePath)
    {
        try
        {
            string[] lines = File.ReadAllLines(filePath);
            char[][] result = new char[lines.Length][];
            for (int i = 0; i < lines.Length; i++)
            {
                result[i] = lines[i].ToCharArray();
            }
            return result;
        }
        catch (Exception e)
        {
            Console.WriteLine($"Error reading file: {e.Message}");
            return null;
        }
    }
}

class SmartTextChecker
{
    public static char[][] ReadFile(string filePath)
    {
        Console.WriteLine($"Opening file {filePath}");
        char[][] result = SmartTextReader.ReadFile(filePath);
        if (result != null)
        {
            Console.WriteLine($"Read {result.Length} lines and {result[0].Length} characters.");
        }
        Console.WriteLine($"Closing file {filePath}");
        return result;
    }
}
class SmartTextReaderLocker
{
    private Regex restrictedFilesRegex;

    public SmartTextReaderLocker(string regexPattern)
    {
        this.restrictedFilesRegex = new Regex(regexPattern);
    }

    public char[][] ReadFile(string filePath)
    {
        if (this.restrictedFilesRegex.IsMatch(filePath))
        {
            Console.WriteLine("Access denied!");
            return null;
        }
        else
        {
            return SmartTextReader.ReadFile(filePath);
        }
    }
}