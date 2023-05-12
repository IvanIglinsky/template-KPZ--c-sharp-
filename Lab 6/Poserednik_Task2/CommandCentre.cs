using Poserednik_Task2;

namespace DesignPatterns.Mediator
{
    class CommandCentre
    {
        public void RequestLanding(Aircraft aircraft)
        {
            if (aircraft.IsLandingAllowed)
            {
                Console.WriteLine("Aircraft #" + aircraft.AircraftNumber + " has been landed successfully!");
                aircraft.IsLanded = true;
                aircraft.IsLandingAllowed = false;
            }
            else
            {
                Console.WriteLine("Aircraft #" + aircraft.AircraftNumber + " cannot land at this moment!");
            }
        }

        public void AllowLanding(Runway runway, Aircraft aircraft)
        {
            if (runway.IsAvailable)
            {
                Console.WriteLine("Runway #" + runway.RunwayNumber + " is now available for landing of Aircraft #" + aircraft.AircraftNumber);
                runway.IsAvailable = false;
                aircraft.IsLandingAllowed = true;
            }
            else
            {
                Console.WriteLine("Runway #" + runway.RunwayNumber + " is busy at the moment! Aircraft #" + aircraft.AircraftNumber + " cannot land now!");
            }
        }

        public void FreeRunway(Runway runway, Aircraft aircraft)
        {
            Console.WriteLine("Aircraft #" + aircraft.AircraftNumber + " has left the runway #" + runway.RunwayNumber);
            runway.IsAvailable = true;
            aircraft.IsLanded = false;
        }
    }
}