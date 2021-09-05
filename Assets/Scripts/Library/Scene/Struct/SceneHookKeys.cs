using System.Collections.Generic;
using UnityHooks;

namespace UnityHooksLibrary.Scene
{
    public static class SceneHookKeys
    {
        public static HookKey<IReadOnlyList<string>> SCENES = new HookKey<IReadOnlyList<string>>(
            "scenes",
            null
        );
    }
}