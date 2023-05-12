using BlackJack;

namespace ClassLibrary.Blackjack.Observer
{
    public class PointsStatistics : IObserver
    {
        private string filePath;
        private int totalPointsCount;
        private int gamesPlayedCount;
        public PointsStatistics(string filePath)
        {
            this.filePath = filePath;
            totalPointsCount = 0;
            gamesPlayedCount = 0;
        }
        public void Update(string message)
        {
            totalPointsCount += int.Parse(message);
            gamesPlayedCount++;
            using (var writer = new StreamWriter(filePath))
            {
                writer.WriteLine($"Average points: {totalPointsCount / (double)gamesPlayedCount}");
            }
        }
    }
}