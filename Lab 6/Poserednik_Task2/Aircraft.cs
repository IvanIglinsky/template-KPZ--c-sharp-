using DesignPatterns.Mediator;

namespace Poserednik_Task2
{
    class Aircraft
    {
        public int AircraftNumber { get; private set; }
        public bool IsLanded { get; set; }
        public bool IsLandingAllowed { get; set; }

        public Aircraft(int number)
        {
            AircraftNumber = number;
            IsLanded = false;
            IsLandingAllowed = false;
        }

        public void Land(Runway runway, CommandCentre commandCentre)
        {
            commandCentre.RequestLanding(this);
            if (IsLanded)
            {
                Console.WriteLine("Aircraft #" + AircraftNumber + " is landing on runway #" + runway.RunwayNumber);
            }
        }

        public void LeaveRunway(Runway runway, CommandCentre commandCentre)
        {
            commandCentre.FreeRunway(runway, this);
        }
    }
}