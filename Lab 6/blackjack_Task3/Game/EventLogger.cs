using BlackJack;

namespace ClassLibrary.Blackjack.Observer
{
    public class EventLogger : IObserver
    {
        private string filePath;
        public EventLogger(string filePath)
        {
            this.filePath = filePath;
        }
        public void Update(string message)
        {
            using (var writer = new StreamWriter(filePath, true))
            {
                writer.WriteLine(message);
            }
        }
    }
}