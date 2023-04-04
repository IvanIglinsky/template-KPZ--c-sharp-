
var Menu = new BigMacMenu();
Menu.PrintMenu();

class BigMacMenu
{
   private readonly Burger _burger;
   private readonly FrenchFries _frenchFries;
   private readonly CocaCola _cocaCola;
   private readonly Pack _pack;
   private readonly Napkins _napkins;
   private readonly Price _price;

   public BigMacMenu()
   {
      _burger = new Burger();
      _frenchFries = new FrenchFries();
      _cocaCola = new CocaCola();
      _pack = new Pack();
      _napkins = new Napkins();
      _price = new Price();
   }

   public void PrintMenu()
   {
       Console.WriteLine("Your menu:");
      _burger.PrintBurger();
      _frenchFries.PrintFrenchFries();
      _cocaCola.PrintCocaCola();
      _pack.PrintPack();
      _napkins.PrintNapkins();
      _price.PrintPrice();
   }
}

class Burger
{
    public void PrintBurger()
    {
        Console.WriteLine("Burger");
    }
}

class FrenchFries
{
    public void PrintFrenchFries()
    {
        Console.WriteLine("FrenchFries");
    }
}

class CocaCola
{
    public void PrintCocaCola()
    {
        Console.WriteLine("CocaCola");
    }
}

class Pack
{
    public void PrintPack()
    {
        Console.WriteLine("Pack");
    }
}

class Napkins
{
    public void PrintNapkins()
    {
        Console.WriteLine("Napkins");
    }
}

class Price
{
    public void PrintPrice()
    {
        Console.WriteLine("Price");
    }
}