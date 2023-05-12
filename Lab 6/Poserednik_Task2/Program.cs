using DesignPatterns.Mediator;
using Poserednik_Task2;

class Program
{
    static void Main(string[] args)
    {
        CommandCentre commandCentre = new CommandCentre();
        Runway runway1 = new Runway(1);
        Runway runway2 = new Runway(2);
        Aircraft aircraft1 = new Aircraft(1);
        Aircraft aircraft2 = new Aircraft(2);

        aircraft1.Land(runway1, commandCentre);
        aircraft2.Land(runway2, commandCentre);
        aircraft1.LeaveRunway(runway1, commandCentre);
        aircraft2.Land(runway1, commandCentre);
        aircraft1.Land(runway2, commandCentre);
        aircraft2.LeaveRunway(runway1, commandCentre);
        aircraft1.LeaveRunway(runway2, commandCentre);
    }
}