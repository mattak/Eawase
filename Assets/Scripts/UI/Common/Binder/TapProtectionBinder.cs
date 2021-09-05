using Eawase.Common.Configuration;
using UniRx;
using UnityEngine;
using UnityHooks;
using UnityHooksLibrary.Renderer;

namespace Eawase.UI.Common.Binder
{
    [RequireComponent(typeof(GameObjectActiveRenderer))]
    public class TapProtectionBinder : MonoBehaviour
    {
        private void Start()
        {
            var renderer = this.GetComponent<GameObjectActiveRenderer>();
            var hook = Hooks.UseState(HookKeys.TapProtect);

            hook.Value
                .Subscribe(renderer.Render)
                .AddTo(this);
        }
    }
}