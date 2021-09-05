using Eawase.Application.Page.Struct;
using Eawase.Common.Scene.Struct;
using UniRx;
using UnityEngine;
using UnityHooks;

namespace Eawase.Application.Page.Binder
{
    public class PageBinder : MonoBehaviour
    {
        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
        static void OnBeforeSceneLoadRuntimeMethod()
        {
            var obj = new GameObject("PageBinder");
            obj.AddComponent<PageBinder>();
            DontDestroyOnLoad(obj);
        }

        private void Start()
        {
            var hook = Hooks.UseState(PageHookKeys.PAGE_STACK);
            hook.Value
                .Where(x => x.Count > 0)
                .Select(x => x.Peek())
                .Subscribe(this.Render)
                .AddTo(this);
        }

        private void Render(Struct.Page page)
        {
            var hook = Hooks.UseState(SceneHookKeys.SCENES);
            hook.Update(page.scenes);
        }
    }
}