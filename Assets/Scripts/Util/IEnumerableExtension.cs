using System.Collections.Generic;

namespace Eawase.Util
{
    public static class IEnumerableExtension
    {
        public static bool IsAllSame<T>(
            this IEnumerable<T> enumerable
        )
        {
            var isFirst = true;
            T target = default;

            foreach (var value in enumerable)
            {
                if (isFirst)
                {
                    target = value;
                    isFirst = false;
                    continue;
                }

                if (!target?.Equals(value) ?? false)
                {
                    return false;
                }
            }

            return true;
        }
    }
}