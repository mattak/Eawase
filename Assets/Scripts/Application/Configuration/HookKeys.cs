using Eawase.Entity;
using UnityHooks;

namespace Eawase.Common.Configuration
{
    public static class HookKeys
    {
        public static readonly HookKey<Stage> Stage = new HookKey<Stage>(
            "cards",
            null
        );

        public static readonly HookKey<bool> TapProtect = new HookKey<bool>(
            "tap_protection",
            false
        );
    }
}