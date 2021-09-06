using Eawase.Entity;
using UnityEngine;

namespace Eawase.UI.Main
{
    public class CardsRenderer : MonoBehaviour
    {
        [SerializeField] private CardBinder[] binders = default;

        public void Render(Stage stage)
        {
            for (var i = 0; i < stage.xSize * stage.ySize; i++)
            {
                binders[i].Bind(stage.GetCard(i));
            }
        }
    }
}