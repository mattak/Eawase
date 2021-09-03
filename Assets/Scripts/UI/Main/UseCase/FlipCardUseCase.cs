using Eawase.Entity;

namespace Eawase.UI.Main
{
    public class FlipCardUseCase
    {
        public FlipResult Execute(Stage stage, Card card)
        {
            if (stage.Flip(card.id) < 2) return new FlipResult { isSuccess = false, isFlippingEnd = false };
            return new FlipResult { isSuccess = stage.Confirm(), isFlippingEnd = true };
        }
    }
}