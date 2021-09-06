using System;
using System.Linq;
using AnimeTask;
using Cysharp.Threading.Tasks;
using Eawase.Util;
using UnityEngine;

namespace Eawase.UI.Main
{
    public class CardsSetupAnimationRenderer : MonoBehaviour
    {
        [SerializeField] private CanvasGroup[] cards = default;

        public void Render()
        {
            RenderAsync().Forget();
        }

        public async UniTask RenderAsync()
        {
            // 1. reveal cards
            foreach (var card in cards)
            {
                card.alpha = 0;
            }

            foreach (var card in cards)
            {
                await Easing.Create<OutQuart>(
                        0f,
                        1f,
                        0.05f
                    )
                    .ToProgress(Progress.Create<float>(x => { card.alpha = x; }));
            }

            await UniTask.Delay(TimeSpan.FromSeconds(0.5f));

            // 2. open cards 
            foreach (var card in cards)
            {
                card.GetComponent<CardBinder>().CardRenderer.RenderForceOpen();
            }

            await UniTask.Delay(TimeSpan.FromSeconds(0.5f));

            // 3. close cards
            foreach (var card in cards)
            {
                card.GetComponent<CardBinder>().CardRenderer.RenderForceClose();
            }

            await UniTask.Delay(TimeSpan.FromSeconds(0.5f));

            // 4. shuffle cards
            var shuffleIndex = Enumerable.Range(0, cards.Length).ToList().Shuffle();
            for (var i = 0; i < shuffleIndex.Count; i++)
            {
                await SwapCards(i, shuffleIndex[i]);
            }
        }

        private async UniTask SwapCards(int from, int to)
        {
            cards[from].alpha = 0;
            cards[to].alpha = 0;
            await UniTask.Delay(TimeSpan.FromSeconds(0.1f));
            cards[from].transform.SetSiblingIndex(to);
            cards[to].transform.SetSiblingIndex(from);
            cards[from].alpha = 1;
            cards[to].alpha = 1;
        }
    }
}