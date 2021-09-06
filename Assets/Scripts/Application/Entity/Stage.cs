using System.Collections.Generic;
using System.Linq;
using Eawase.Util;

namespace Eawase.Entity
{
    public class Stage
    {
        public int xSize = -1;
        public int ySize = -1;
        public IReadOnlyList<Card> cards => _cardMap.Values.ToList();
        private IDictionary<int, Card> _cardMap = new Dictionary<int, Card>();
        private List<int> _flipList = new List<int>();

        public void SetUp(int xSize, int ySize, IReadOnlyList<Card> cards)
        {
            this.xSize = xSize;
            this.ySize = ySize;

            for (var i = 0; i < cards.Count; i++)
            {
                var id = cards[i].id;
                this._cardMap[id] = cards[i];
            }
        }

        public Card GetCard(int id) => _cardMap[id];

        public int GetRemainCardCount()
        {
            return _cardMap
                .Count(x => !x.Value.isOpened);
        }

        public int GetFlippingCardCount()
        {
            return _flipList.Count;
        }

        public int Flip(int id)
        {
            var card = _cardMap[id];
            card.isOpened = true;

            this._flipList.Add(id);
            return this._flipList.Count;
        }

        public bool Confirm()
        {
            var isSuccess = this._flipList
                .Select(id => this._cardMap[id].type.groupId)
                .IsAllSame();

            foreach (var id in _flipList)
            {
                UnityEngine.Debug.Log($"Flip[{id}].type.groupId = {this._cardMap[id].type.groupId}");
            }

            UnityEngine.Debug.Log($"Confirm.isSuccess: {isSuccess}");
            return isSuccess;
        }

        public void ResetFlipList(bool isSuccess)
        {
            foreach (var id in _flipList)
            {
                UnityEngine.Debug.Log($"Flip[{id}].type.groupId = {this._cardMap[id].type.groupId} as {isSuccess}");
                this._cardMap[id].isOpened = isSuccess;
            }

            this._flipList.Clear();
        }

        public bool IsAllFlipped()
        {
            return this._cardMap.All(x => x.Value.isOpened) && !this._flipList.Any();
        }
    }
}