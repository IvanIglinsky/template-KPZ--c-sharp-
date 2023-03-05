using System.Text;
using ConsoleApp1;
Console.OutputEncoding=Encoding.UTF8;
Money money = new Money(10, 25);
Product product = new Product("Apple",money.GetBGM(),money.GetSM());
product.LessMoney(5);
Reporting reporting = new Reporting(product.GetBGM(), product.GetSM(), product.GetName(), "Шт.", 10, "15.02.2023");
Console.WriteLine("\nДоступні гроші:\n");
reporting.ShowMoney();
Console.WriteLine("\nРеєстрація надходження товару\n");
reporting.RegisterTovar();
Console.WriteLine("\nВідвантаження\n");
reporting.VidatTovar(1);
Console.WriteLine("\nІнвентаризація\n");
reporting.Inventory(1);
namespace ConsoleApp1
{
    interface IMoney
    {
        void ShowMoney();
        float AllMoney();

    }
    

    internal class Money :IMoney
    {
        private int BigMoney { get; set; }
        public int GetBGM()
        {
            return BigMoney;
        }
        private int SmallMoney { get; set; }

        public int GetSM()
        {
            return SmallMoney;
        }
        public Money(int bgMoney,int smMoney)
        {
            BigMoney = bgMoney;
            SmallMoney = smMoney;
        }

        public float AllMoney()
        {
            return float.Parse(BigMoney+"."+SmallMoney);
        }
        public void ShowMoney()
        {
            Console.WriteLine("You have {0}.{1}",BigMoney,SmallMoney);
        }
        //usage open-close principle
    }

    internal class Product : Money
    {
       
        private string Name { get; set; }

        public string GetName()
        {
            return Name;
        }
        public Product(string name, int bgMoney, int smMoney) : base(bgMoney, smMoney)
        {
            Name = name;
        }
        
        public float LessMoney(float price)
        {
            return AllMoney() - price;
        }
        /*A class is used for only one method.  (Single responsibility)  */
    }

    internal class Warehouse:Product
    {
        private  string CountetOfName { get; set; }

        protected string GetCountetOfName()
        {
            return CountetOfName;
        }
  
        private  int Count { get; set; }

        protected int GetCount()
        {
            return Count;
        }

        private string Date { get; set; }

        protected string GetDate()
        {
            return Date;
        }
       
        protected Warehouse(int bgMoney, int smMoney,string name, string CountOfName, int count,string date) : base(name, bgMoney, smMoney)
        {
            CountetOfName = CountOfName;
            Count = count;
            Date = date;
        }
        //Open-close principle
    }

    internal class Reporting :Warehouse
    {  
        
        public Reporting(int bgMoney, int smMoney, string name, string CountOfName, int count, string date) : base(bgMoney, smMoney, name, CountOfName, count, date)
        {
        }
        //The substitution principle of Barbara Lyskov was used
        public void RegisterTovar()
        {
          Console.WriteLine(
              "Найменування:{0}\nОдиниця вимірювання:{1}\nЦіна одиниці:{2}\nКількість:{3}\n" +
              "Дата поставки:{4}",GetName(),GetCountetOfName(),AllMoney(),GetCount(),GetDate()
              );
        }

        public void VidatTovar(int num)
        {
            Console.WriteLine("№{0}\nТовар:{1}\nКількість:{2}\nОдиниці вимірювання:{3}\nЦіна:{4}",
                num,GetName(),GetCount(),GetCountetOfName(),AllMoney()
                );  
        }

        public void Inventory(int num)
        {
            Console.WriteLine("№{0}\nНазва:{1}\nКількість:{2}",num,GetName(),GetCount());
        }
    }
    
}
