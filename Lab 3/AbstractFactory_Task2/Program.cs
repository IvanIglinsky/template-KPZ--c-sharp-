using AbstractFactory_Task2;
using System.Text;
Console.OutputEncoding=Encoding.UTF8;

for (int i = 0; i < 10; i++)
{
    var People = new TypeOfPeople();
    var Clothes = new TypeOfClothes();
    var factory = new Factory();
    factory.Generate(People,Clothes);
}

namespace AbstractFactory_Task2
{
    interface IClothes
    {
        public string[] clothes { get; set; }
        public string RandomClothes();
    }

    interface IPeople
    {
        public string[] people { get; set; }
        public string RandomPeople();
    }

    interface IFactory
    {
        public void Generate(IPeople people,IClothes clothes);
    }

    class TypeOfClothes:IClothes
    {
        public string[] clothes { get; set; }

        public TypeOfClothes()
        {

            clothes = new string[]
            {
                "кросівки", "шакарпетки", "шапки", "футболки", "штани",
                "світшоти", "куртки", "шорти"
            };
        }

        public string RandomClothes()
        {
            var random = new Random();
            int numClothes = random.Next(0,8);
            return clothes[numClothes];
        }
    }

    class TypeOfPeople:IPeople
    {
        public string[] people { get; set; }
        

        public TypeOfPeople()
        { 
            people =new string[] { "чоловічі","жіночі","дитячі" };
        }
        public string RandomPeople()
        {
            var random = new Random();
            int numPeople=random.Next(0, 3);
            return people[numPeople];
        }
       
    }

    class Factory :IFactory
    {
        public void Generate(IPeople people, IClothes clothes)
        {
 
            Console.WriteLine("На фабриці пошито {0} {1}",people.RandomPeople(),clothes.RandomClothes());
        }
    }
}