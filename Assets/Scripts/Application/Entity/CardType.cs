using System;
using UnityEngine;

namespace Eawase.Entity
{
    [Serializable]
    public class CardType
    {
        public readonly int groupId;
        public readonly Color color;

        public CardType(int groupId, Color color)
        {
            this.groupId = groupId;
            this.color = color;
        }
    }
}