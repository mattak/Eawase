using UniRx;
using UnityEngine;
using UnityHooks;
using UnityHooksLibrary.Scene;

namespace UnityHooksLibrary.Page
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

        private void Render(Page page)
        {
            var hook = Hooks.UseState(SceneHookKeys.SCENES);
            hook.Update(page.scenes);
        }
    }
}