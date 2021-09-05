using System.Collections.Generic;
using UnityHooks;

namespace Eawase.Application.Page.Struct
{
    public static class PageHookKeys
    {
        public static HookKey<Stack<Page>> PAGE_STACK = new HookKey<Stack<Page>>(
            "page_stack",
            new Stack<Page>()
        );
    }
}