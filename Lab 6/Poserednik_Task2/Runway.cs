using Poserednik_Task2;

namespace DesignPatterns.Mediator
{
    class Runway
    {
        public int RunwayNumber { get; private set; }
        public bool IsAvailable { get; set; }

        public Runway(int number)
        {
            RunwayNumber = number;
            IsAvailable = true;
        }
    }
}