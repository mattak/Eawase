using System.Collections.Generic;
using Eawase.Entity;
using UnityEngine;
using UnityEngine.Assertions;

namespace Eawase.UI.Main
{
    public class CardsRenderer : MonoBehaviour
    {
        [SerializeField] private CardBinder[] binders = default;

        public void Render(IReadOnlyList<Card> cards)
        {
            for (var i = 0; i < cards.Count; i++)
            {
                binders[i].Bind(cards[i]);
            }
        }
    }
}