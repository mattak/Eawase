using Eawase.Common.Configuration;
using Eawase.Entity;
using UniRx;
using UnityEngine;
using UnityHooks;

namespace Eawase.UI.Main
{
    public class StageBinder : MonoBehaviour
    {
        [SerializeField] private int xSize = 5;
        [SerializeField] private int ySize = 6;
        [SerializeField] private CardsRenderer cardsRenderer = default;
        [SerializeField] private GameObject congradulationsBanner = default;

        private void Start()
        {
            var stageHook = Hooks.UseState(HookKeys.Stage);

            Initialize(stageHook);

            stageHook.Value
                .Where(x => x != null)
                .Where(x => x.IsAllFlipped())
                .Subscribe(_ => UnityEngine.Debug.Log("Congratulations!!"))
                .AddTo(this);
            stageHook.Value
                .Where(x => x != null)
                .Select(x => x.cards)
                .Subscribe(cardsRenderer.Render)
                .AddTo(this);
            stageHook.Value
                .Where(x => x != null)
                .Select(x => x.IsAllFlipped())
                .Subscribe(x => congradulationsBanner.SetActive(x))
                .AddTo(this);
        }

        private void Initialize(Hook<Stage> hook)
        {
            var useCase = new InitializeStageUseCase();
            var stage = useCase.Execute(xSize, ySize);
            hook.Update(stage);
        }
    }
}