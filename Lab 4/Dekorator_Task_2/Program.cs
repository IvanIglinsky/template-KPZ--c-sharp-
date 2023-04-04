var hero = new Warrior("Sven");//hero Sven(DOTA 2)
var sword = new Item("Sword", 80);//Sword +80 damage
var boots = new Item("Boots", 45);//Boots +45 move speed 
var blinkDagger = new Item("Blink", 5);//+5 for all and teleport to a target point up to 1200 units away


var swordWeapon = new Weapon(sword);
var swordInWeaponAndArtifact = new Artifact(swordWeapon);
var bootsInClothing = new Clothing(boots);
var blinkDaggerInArtefact = new Artifact(blinkDagger);
var blinkDaggerInArtefactAndClothing = new Clothing(blinkDaggerInArtefact);

hero.AddToInventory(swordInWeaponAndArtifact);
hero.AddToInventory(bootsInClothing);
hero.AddToInventory(blinkDaggerInArtefactAndClothing);

Console.WriteLine(hero);
Console.WriteLine("Inventory:");
Console.WriteLine(hero.Inventory[0].Name);
Console.WriteLine(hero.Inventory[1].Name);
Console.WriteLine(hero.Inventory[2].Name);


public interface IItem
{
    string Name { get; }
    int Bonus { get; }
    Item Parent { get; }
}

public class Item : IItem
{
    public string Name { get; }
    public int Bonus { get; }
    public Item Parent { get; }

    public Item(string name, int bonus)
    {
        Name = name;
        Bonus = bonus;
    }
}

public class Clothing : Item
{
    public Clothing(IItem item) : base($"{item.Name} (Clothing)", item.Bonus)
    {
    }
}

public class Weapon : Item
{
    public Weapon(IItem item) : base($"{item.Name} (Weapon)", item.Bonus)
    {
    }
}


public class Artifact : Item
{
    public Artifact(IItem item) : base($"{item.Name} (Artifact)", item.Bonus)
    {
        Parent = item;
    }

    public IItem Parent { get; }
}

public abstract class Hero
{
    public string Name { get; set; }
    public int Health { get; set; } = 100;
    public List<Item> Inventory { get; set; } = new List<Item>();

    public Hero(string name)
    {
        Name = name;
    }
    public void AddToInventory(Item item)
    {
        Inventory.Add(item);

        // add parent items recursively
        if (item.Parent != null)
        {
            AddToInventory(item.Parent);
        }
    }
}



public class Warrior : Hero
{
    public Warrior(string name) : base(name)
    {
        
    }
}

public class Mage : Hero
{
    public Mage(string name) : base(name)
    {
        
    }
}

public class Paladin : Hero
{
    public Paladin(string name) : base(name)
    {
        
    }
}