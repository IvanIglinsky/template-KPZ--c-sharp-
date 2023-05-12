using BlackJack;
using blackjack.Game;

namespace ClassLibrary.Blackjack.Strategy
{
    public class RiskyStrategy : IStrategy
    {
        public void Play(Player player, GameState state)
        {
            int playerPoints = PointsCounter.CountSum(player.DrawnCards);
            while (playerPoints < 19 && player.ConfirmNextDraw())
            {
                player.DrawCard(state.Deck);
                playerPoints = PointsCounter.CountSum(player.DrawnCards);
            }
        }
    }
}