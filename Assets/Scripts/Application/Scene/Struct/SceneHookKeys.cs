using System.Collections.Generic;
using UnityHooks;

namespace Eawase.Common.Scene.Struct
{
    public static class SceneHookKeys
    {
        public static HookKey<IReadOnlyList<string>> SCENES = new HookKey<IReadOnlyList<string>>(
            "scenes",
            null
        );
    }
}