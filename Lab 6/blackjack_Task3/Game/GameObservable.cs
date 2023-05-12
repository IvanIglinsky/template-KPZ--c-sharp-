using BlackJack;
using blackjack.Game;

namespace ClassLibrary.Blackjack.Observer
{
    public class GameObservable : IObservable
    {
        private List<IObserver> observers = new List<IObserver>();
        public void AddObserver(IObserver observer)
        {
            this.observers.Add(observer);
        }
        public void RemoveObserver(IObserver observer)
        {
            this.observers.Remove(observer);
        }
        public void NotifyObservers(string message)
        {
            foreach (var observer in this.observers)
            {
                  observer.Update(message);
            }
        }
    }
}