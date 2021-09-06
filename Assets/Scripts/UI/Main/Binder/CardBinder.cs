using System;
using Cysharp.Threading.Tasks;
using Eawase.Common.Configuration;
using Eawase.Common.Input;
using Eawase.Entity;
using UniRx;
using UnityEngine;
using UnityHooks;

namespace Eawase.UI.Main
{
    public class CardBinder : MonoBehaviour
    {
        [SerializeField] private CardRenderer renderer = default;
        [SerializeField] private ImageInput input = default;

        private Card card = default;

        public CardRenderer CardRenderer => renderer;

        private void Start()
        {
            input.pressedAsObservable
                .Where(_ => card != null)
                .Subscribe(_ => SelectCard(this.card))
                .AddTo(this);
        }

        public void Bind(Card card)
        {
            var stage = Hooks.UseState(HookKeys.Stage);
            var id = card.id;
            stage.Value
                .Where(x => x != null)
                .Select(x => x.GetCard(id))
                .Subscribe(x =>
                {
                    this.card = card;
                    renderer.Render(card);
                })
                .AddTo(this);
        }

        private async UniTask SelectCard(Card card)
        {
            var tapProtectionHook = Hooks.UseState(HookKeys.TapProtect);
            tapProtectionHook.Update(true);

            var stageHook = Hooks.UseState(HookKeys.Stage);
            var useCase = new FlipCardUseCase();
            var result = useCase.Execute(stageHook.Current, card);
            stageHook.Update(stageHook.Current);

            if (result.isFlippingEnd)
            {
                // a little bit waiting until reset
                if (!result.isSuccess) await UniTask.Delay(TimeSpan.FromSeconds(2f));

                stageHook.Current.ResetFlipList(result.isSuccess);
                stageHook.Update(stageHook.Current);
            }

            tapProtectionHook.Update(false);
        }
    }
}