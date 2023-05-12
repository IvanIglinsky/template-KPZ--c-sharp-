using BlackJack;
using ClassLibrary.Blackjack;

namespace blackjack.Game;

public class CautiousStrategy : IStrategy
{
    public void Play(Player player, GameState state)
    {
        int playerPoints = PointsCounter.CountSum(player.DrawnCards);
        while (playerPoints < 13 && player.ConfirmNextDraw())
        {
            player.DrawCard(state.Deck);
            playerPoints = PointsCounter.CountSum(player.DrawnCards);
        }
    }
}