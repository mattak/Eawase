using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;
using UnityHooks;

namespace UnityHooksLibrary.Page
{
    [RequireComponent(typeof(Button))]
    public class PagePushButtonBinder : MonoBehaviour
    {
        [SerializeField] private Page page = default;
        
        private void Start()
        {
            Bind().Forget();
        }

        private async UniTask Bind()
        {
            await GetComponent<Button>().OnClickAsync();
            var hook = Hooks.UseState(PageHookKeys.PAGE_STACK);
            var stack = hook.Current;
            stack.Push(page);
            hook.Update(stack);
        }
    }
}