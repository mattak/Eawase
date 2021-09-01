using Eawase.Common.Scene.Struct;
using UniRx;
using UnityEngine;
using UnityEngine.Assertions;
using UnityHooks;
using UnityHooks.Input;

namespace Eawase.Common.Scene.Binder
{
    [RequireComponent(typeof(ButtonInput))]
    public class SceneChangeButtonBinder : MonoBehaviour
    {
        [SerializeField] private string[] _loadScenes = default;

        private void Start()
        {
            Assert.IsTrue(_loadScenes != default, $"_loadScenes is default. please attach on {gameObject.name}");
            var hook = Hooks.UseState(SceneHookKeys.SCENES);

            this.GetComponent<ButtonInput>()
                .clickAsObservable
                .Select(_ => _loadScenes)
                .Subscribe(hook.Update)
                .AddTo(this);
        }
    }
}