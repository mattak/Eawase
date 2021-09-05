using System;

namespace Eawase.Entity
{
    [Serializable]
    public class Card
    {
        public readonly int id;
        public readonly CardType type;
        public bool isOpened;

        public Card(int id, CardType type)
        {
            this.id = id;
            this.type = type;
            this.isOpened = false;
        }
    }
}