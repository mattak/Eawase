using Cysharp.Threading.Tasks;
using Eawase.Application.Page.Struct;
using UnityEngine;
using UnityEngine.UI;
using UnityHooks;
using UnityHooks.Input;

namespace Eawase.Application.Page.Binder
{
    [RequireComponent(typeof(Button))]
    public class PagePopButtonBinder : MonoBehaviour
    {
        private void Start()
        {
            Bind().Forget();
        }

        private async UniTask Bind()
        {
            await GetComponent<Button>().OnClickAsync();
            var hook = Hooks.UseState(PageHookKeys.PAGE_STACK);
            var stack = hook.Current;
            if (stack.Count <= 1)
            {
                Debug.LogWarning("Cannot pop page. its root page");
                return;
            }
            
            stack.Pop();
            hook.Update(stack);
        }
    }
}