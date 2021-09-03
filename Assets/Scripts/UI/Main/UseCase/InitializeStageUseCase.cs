using System.Collections.Generic;
using Eawase.Entity;
using UnityEngine;

namespace Eawase.UI.Main
{
    public class InitializeStageUseCase
    {
        public Stage Execute(int xSize, int ySize)
        {
            var cards = GenerateCards(xSize, ySize);
            var stage = new Stage();
            stage.SetUp(xSize, ySize, cards);
            return stage;
        }

        private IReadOnlyList<Card> GenerateCards(int xSize, int ySize)
        {
            var size = xSize * ySize;
            var result = new Card[size];
            for (var i = 0; i < size / 2; i++)
            {
                var offset = i * 2;
                var type = new CardType(i, GenerateRandomColor());
                result[offset] = new Card(offset, type);
                result[offset + 1] = new Card(offset + 1, type);
            }

            return result;
        }

        private Color GenerateRandomColor()
        {
            var r = Random.Range(0f, 1f);
            var g = Random.Range(0f, 1f);
            var b = Random.Range(0f, 1f);
            return new Color(r, g, b);
        }
    }
}