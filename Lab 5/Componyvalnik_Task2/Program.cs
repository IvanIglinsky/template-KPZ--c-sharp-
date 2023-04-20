
using System.Text;
using DesignPatterns.Composite;
Console.OutputEncoding=Encoding.UTF8;

    var mainHero = new MarvelHero("Tony Stark",150);
    var ironMan = new MarvelHero("Iron Man",100);
    mainHero.AddFriend(ironMan);

   // var pureContainer = new ArtefactContainer();
   // mainHero.AddArtefactContainer(pureContainer);

    var glove = new CompositeArtefact("GloveOfPower",50,25);
    ironMan.AddArtefact(glove);

    for (int i = 0; i < 5; i++)
    {
        var infinityStone = new Artefact("infinityStone"+i + 1,10,5);
        glove.AddArtefact(infinityStone);
    }
ironMan.CountArtefacts();
mainHero.RemoveFriend(ironMan);
Console.ReadKey();
