using System.Text;
Console.OutputEncoding=Encoding.UTF8;
VirusChild[] Viruses = new VirusChild[] { };
var virus=new Virus(100,20,"Covid","Toxic",Viruses);
var Child1 = new VirusChild(10,4,"Covid-19","Toxic",Viruses,"20.12.2019",virus);
var Child2 = Child1.Clone(11,3,"Covid-20","Toxic",Viruses,"15.11.2020",virus);
var Child3 = Child1.Clone(12,2,"Covid-21","Toxic",Viruses,"15.11.2021",virus);
var Child4 = Child1.Clone(13,1,"Covid-22","Toxic",Viruses,"15.11.2022",virus);

Viruses.Append(Child1);
Viruses.Append(Child2);
Viruses.Append(Child3);
Viruses.Append(Child4);
Child1.About();
Child2.About();
Child3.About();
Child4.About();
virus.About();

class Virus
{
    public float weight;
    public float age;
    public string name;
    public string vid; 
    public VirusChild[] VirusChild1;

    public Virus(float weight,float age, string name,string vid, VirusChild[] virusChild1)
    {
        this.name = name;
        this.vid = vid;
        VirusChild1 = virusChild1;
        this.age = age;
        this.weight = weight;
    }
    public  Virus Clone(float weight,float age, string name,string vid, VirusChild[] virusChild1)
    {
        return new Virus(weight,age,name,vid,VirusChild1);
    }

    public void About()
    {
        Console.WriteLine("Вага:{0}",weight);
        Console.WriteLine("Вік:{0}",age);
        Console.WriteLine("Ім'я:{0}",name);
        Console.WriteLine("Вид:{0}\n\n",vid);
    }


}
class VirusChild:Virus
{
    public string birthDate;
    public Virus parent;
    public VirusChild(float weight, float age, string name, string vid, VirusChild[] virusChild1,string birthDate,Virus parent) : base(weight, age, name, vid, virusChild1)
    {
        this.birthDate = birthDate;
        this.parent = parent;
    }
    public  VirusChild Clone(float weight, float age, string name, string vid, VirusChild[] virusChild1,string birthDate,  Virus parent)
    {
        return new VirusChild(weight,  age,  name,  vid, virusChild1, birthDate,parent);
    }

    public void About()
    {
        Console.WriteLine("Вага:{0}",weight);
        Console.WriteLine("Вік:{0}",age);
        Console.WriteLine("Ім'я:{0}",name);
        Console.WriteLine("Вид:{0}",vid);
        Console.WriteLine("Батько:{0}\n\n",parent);
    }
        
}