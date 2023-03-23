Console.WriteLine("\nГерой\n");
var Hero = new HeroBuilder("Чудик","180","Black","Green","Full set clothes","AK-47,knife,key BMW");
Hero.About();
Console.WriteLine("\nВорог\n");
var Enemy = new EnemyBuilder("Тюбик","175","White","Blue","Half set clothes","nothing");
Enemy.About();
interface IBuilder
{
    public string Name { get; set; }
    public string height { get; set; }
    public string hairColor{ get; set; }
    public string EyeColor{ get; set; }
    public string Clothes{ get; set; }
    public string Inventory{ get; set; }
    
}

class HeroBuilder:IBuilder
{
    public string Name { get; set; }
    public string height { get; set; }
    public string hairColor { get; set; }
    public string EyeColor { get; set; }
    public string Clothes { get; set; }
    public string Inventory { get; set; }
    public HeroBuilder(string name, string height, string hairColor, string eyeColor, string clothes, string inventory)
    {
        Name = name;
        this.height = height;
        this.hairColor = hairColor;
        EyeColor = eyeColor;
        Clothes = clothes;
        Inventory = inventory;
    }

    public void About()
    {
        Console.WriteLine($"Name:{Name}");
        Console.WriteLine($"Height:{height}");
        Console.WriteLine($"Hair color:{hairColor}");
        Console.WriteLine($"Eyes color:{EyeColor}");
        Console.WriteLine($"Clothes:{Clothes}");
        Console.WriteLine($"Inventory:{Inventory}");
    }
}

class EnemyBuilder : IBuilder
{
    public string Name { get; set; }
    public string height { get; set; }
    public string hairColor { get; set; }
    public string EyeColor { get; set; }
    public string Clothes { get; set; }
    public string Inventory { get; set; }
    public EnemyBuilder(string name, string height, string hairColor, string eyeColor, string clothes, string inventory)
    {
        Name = name;
        this.height = height;
        this.hairColor = hairColor;
        EyeColor = eyeColor;
        Clothes = clothes;
        Inventory = inventory;
    }
    public void About()
    {
        Console.WriteLine($"Name:{Name}");
        Console.WriteLine($"Height:{height}");
        Console.WriteLine($"Hair color:{hairColor}");
        Console.WriteLine($"Eyes color:{EyeColor}");
        Console.WriteLine($"Clothes:{Clothes}");
        Console.WriteLine($"Inventory:{Inventory}");
    }
}