using System.Text;
Console.OutputEncoding=Encoding.UTF8;

int ChooseKey()
{
    Console.WriteLine("Для покупки виберіть один із типів підписки" +
                      "(1-3)\n1-DomesticSubscriotion\n2-EducationalSubscription\n" +
                      "3-PremiumSubscription");
    int key = Convert.ToInt32(Console.ReadLine());
    return key;
}

void AfterBuy( string NameSub ,float price)
{
    Console.WriteLine("Тип підписки:{0}", NameSub);
    Console.WriteLine("Сума до сплати:{0}",price);
}
int ChooseCountOfMonth()
{
    
    Console.WriteLine("Вкажіть кількість місяців для підписки:");
    int count = Convert.ToInt32(Console.ReadLine());
    return count;
}
int key= ChooseKey();
while (key > 3 || key < 1)
{
    Console.WriteLine("Не правильний вибір");
    key = ChooseKey();
    Console.Clear();
}

if (key >= 1 && key<=3)
{
    int countMonth = ChooseCountOfMonth();
    Console.WriteLine("Виберіть спосіб купівлі:\n1)Сайт\n2)Мобільний додаток\n3)" +
                      "Виклик оператору");
    int keyToBuy = Convert.ToInt32(Console.ReadLine());
    
    if (keyToBuy == 1)
    {
      var  buy = new WebSite(countMonth, key);
      AfterBuy(buy.NameSub,buy.price);
      Console.WriteLine("\nЧек прийде вам на пошту");
    }
    else if(keyToBuy==2)
    {
       var buy = new MobileApp(countMonth, key);
       AfterBuy(buy.NameSub,buy.price);
       Console.WriteLine("\nЧек прийде вам в додаток");
    }
    else if(keyToBuy==3)
    {
        var buy = new ManagerCall(countMonth, key);
        AfterBuy(buy.NameSub,buy.price);
        Console.WriteLine("\nЧек прийде вам в паперовому вигляді");
    }
    else
    {
        Console.WriteLine("Спробуйте пізніше!");
        return;
    }
   
    
}

void About(string name, float priceOfMonth, string Prv,string[]list)
{
    Console.WriteLine("Назва підписки:{0}",name);
    Console.WriteLine("Ціна за місяць(грн):{0}",priceOfMonth);
    Console.WriteLine("Привілегії:{0}",Prv);
    Console.WriteLine("Список каналів:");
    for (int i = 0; i < list.Length; i++)
    {
        Console.Write(list[i]+", ");
    }
}

interface Subscription
{
    string Name { get; set; }
    float PriceForMonth { get; set; }
    string Privileges { get; set; }
    float MinPeriodPerMonth { get; set; }
    string[] ListOfChannel { get; set; }
}

class DomesticSubscriotion: Subscription
{
    private Subscription sub;
    
    public string Name { get;set;}  
    public float PriceForMonth
    {
        get;
        set;
    }

    public float MinPeriodPerMonth
    {
        get;
        set;
    }

    public string[] ListOfChannel { get; set; }

    public string Privileges
    {
        get;
        set;
    }
    

    public DomesticSubscriotion()
    {
        Name = "DomesticSubscriotion";
        PriceForMonth = 200;
        Privileges = "Free 5 chanel";
        MinPeriodPerMonth = 2;
        ListOfChannel = new string[]{"1+1", "2+2", "Перший", "ICTV", "СТБ"};
    }

   
}

class EducationalSubscription : Subscription
{
    private Subscription _subscriptionImplementation;
    public string Name { get; set; }

    public float PriceForMonth
    {
        get;
        set;
    }
    public float MinPeriodPerMonth
    {
        get;
        set;
    }
    public string Privileges
    {
        get;
        set;
    }

    public string[] ListOfChannel
    {
        get;
        set;
    }

    public EducationalSubscription()
    {
        Name = "EducationalSubscription";
        PriceForMonth = 400;
        Privileges = "Free 10 chanel";
        MinPeriodPerMonth = 5;
        ListOfChannel =new string[] {"1+1", "2+2", "Перший", "ICTV", "СТБ", "TET", "Мега", "ПлюПлюс", "М1", "M2", "K1"};
    }
}

class PremiumSubscription : Subscription
{
    private Subscription _subscriptionImplementation;
    public string Name
    {
        get;
        set;
    }
    public float MinPeriodPerMonth
    {
        get;
        set;
    }
    public float PriceForMonth
    {
        get;
        set;
    }

    public string Privileges
    {
        get;
        set;
    }

    public string[] ListOfChannel
    {
        get;
        set;
    }
    public PremiumSubscription()
    {
        Name = "EducationalSubscription";
        PriceForMonth = 600;
        Privileges = "Access all channel";
        MinPeriodPerMonth = 10;
        ListOfChannel =new string[] {"1+1", "2+2", "Перший", "ICTV", "СТБ", "TET", "Мега", "ПлюПлюс", "М1", "M2", "K1","XSports","Football 1" };
    }
}

interface IBuy
{
    public int Count { get; set; }
    public int Type { get; set; }
    public string NameSub { get; set; }
    public float price { get; set; }
}

class WebSite:IBuy
{
    public int Count { get; set; }
    public int Type { get; set; }
    public string NameSub { get; set; }
    public float price { get; set; }
    
    
    public WebSite(int countMonth,int typeOfSubscription)
    {
        Console.WriteLine("\nКупівля була здійснена через сайт TVChannel.Приємного перегляду!!!\n");
        Count = countMonth;
        Type = typeOfSubscription;
        if (Type == 1)
        {
            var DS = new DomesticSubscriotion();
            price = Count * DS.PriceForMonth;
            NameSub = DS.Name;
        }
        else if(Type==2)
        {
            var ES = new EducationalSubscription();
            price = Count * ES.PriceForMonth;
            NameSub = ES.Name;
        }
        else if(Type==3)
        {
            var PS = new PremiumSubscription();
            price = Count * PS.PriceForMonth;
            NameSub = PS.Name;
        }
        
    }
}

class MobileApp:IBuy
{
    public int Count { get; set; }
    public int Type { get; set; }
    public string NameSub { get; set; }
    public float price { get; set; }

    public MobileApp(int countMonth,int typeOfSubscription)
    {
        Console.WriteLine("\nКупівля була здійснена через мобільний додаток MobileTVChannel.Приємного перегляду!!!\n");
        Count = countMonth;
        Type = typeOfSubscription;
        if (Type == 1)
        {
            var DS = new DomesticSubscriotion();
            price = Count * DS.PriceForMonth;
            NameSub = DS.Name;
        }
        else if(Type==2)
        {
            var ES = new EducationalSubscription();
            price = Count * ES.PriceForMonth;
            NameSub = ES.Name;
        }
        else if(Type==3)
        {
            var PS = new PremiumSubscription();
            price = Count * PS.PriceForMonth;
            NameSub = PS.Name;
        }
    }
}

class ManagerCall : IBuy
{
    public int Count { get; set; }
    public int Type { get; set; }
    public string NameSub { get; set; }
    public float price { get; set; }

    public ManagerCall(int countMonth,int typeOfSubscription)
    {
        Console.WriteLine("\nКупівля була здійснена через телефоний дзвінок оператору.Приємного перегляду!!!\n");
        Count = countMonth;
        Type = typeOfSubscription;
        if (Type == 1)
        {
            var DS = new DomesticSubscriotion();
            price = Count * DS.PriceForMonth;
            NameSub = DS.Name;
        }
        else if(Type==2)
        {
            var ES = new EducationalSubscription();
            price = Count * ES.PriceForMonth;
            NameSub = ES.Name;
        }
        else if(Type==3)
        {
            var PS = new PremiumSubscription();
            price = Count * PS.PriceForMonth;
            NameSub = PS.Name;
        }
    }
}