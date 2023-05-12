using BlackJack;

namespace blackjack.Game;

public interface IObservable
{
    void AddObserver(IObserver observer);
    void RemoveObserver(IObserver observer);
    void NotifyObservers(string message);
}
