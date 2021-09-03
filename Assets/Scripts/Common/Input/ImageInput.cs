using System;
using UniRx.Triggers;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Eawase.Common.Input
{
    [RequireComponent(typeof(Image))]
    public class ImageInput : UIBehaviour
    {
        public IObservable<PointerEventData> pressedAsObservable => this.GetComponent<Image>()
            .OnPointerDownAsObservable();
    }
}