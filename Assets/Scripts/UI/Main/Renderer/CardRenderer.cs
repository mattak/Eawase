using Eawase.Entity;
using UnityEngine;
using UnityEngine.UI;

namespace Eawase.UI.Main
{
    [RequireComponent(typeof(Image))]
    public class CardRenderer : MonoBehaviour
    {
        [SerializeField] private Card card = default;
        private Image image = default;

        private void Awake()
        {
            this.image = GetComponent<Image>();
        }

        public void Render(Card card)
        {
            this.card = card; // for debug
            this.image.color = card.isOpened ? card.type.color : Color.gray;
        }

        public void RenderForceOpen()
        {
            this.image.color = card.type.color;
        }
        
        public void RenderForceClose()
        {
            this.image.color = Color.grey;
        }
    }
}