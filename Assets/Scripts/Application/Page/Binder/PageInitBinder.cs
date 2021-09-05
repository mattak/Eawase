using Eawase.Application.Page.Struct;
using UnityEngine;
using UnityHooks;

namespace Eawase.Application.Page.Binder
{
    public class PageInitBinder : MonoBehaviour
    {
        [SerializeField] private Struct.Page page = default;

        private void Start()
        {
            var hook = Hooks.UseState(PageHookKeys.PAGE_STACK);
            var stack = hook.Current;
            if (stack.Count > 0) return;
            stack.Push(page);
            hook.Update(stack);
        }
    }
}