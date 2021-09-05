using System.Collections.Generic;

namespace Eawase.Util
{
    public static class ListExtension
    {
        public static List<T> Shuffle<T>(this List<T> list)
        {
            for (var i = 0; i < list.Count; i++)
            {
                var from = i;
                var to = UnityEngine.Random.Range(0, list.Count);
                (list[@from], list[to]) = (list[to], list[@from]);
            }

            return list;
        }
    }
}