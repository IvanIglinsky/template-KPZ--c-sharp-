using BlackJack;
using ClassLibrary.Blackjack;

namespace blackjack.Game;

public interface IStrategy
{
    void Play(Player player, GameState state);
}
