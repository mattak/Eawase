using Eawase.Common.Scene.Renderer;
using Eawase.Common.Scene.Struct;
using UniRx;
using UnityEngine;
using UnityHooks;

namespace Eawase.Common.Scene.Binder
{
    public class SceneBinder : MonoBehaviour
    {
        private SceneRenderer _sceneRenderer = new SceneRenderer();

        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
        static void OnBeforeSceneLoadRuntimeMethod()
        {
            var obj = new GameObject("SceneBinder");
            obj.AddComponent<SceneBinder>();
            DontDestroyOnLoad(obj);
        }

        private void Start()
        {
            var hook = Hooks.UseState(SceneHookKeys.SCENES);

            hook.Value
                .Where(x => x != null)
                .Subscribe(_sceneRenderer.Render)
                .AddTo(this);
        }
    }
}