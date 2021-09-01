using System;
using UniRx;
using UnityEngine;
using UnityHooks.Input;

namespace Eawase
{
    public class TitleButtonBinder : MonoBehaviour
    {
        [SerializeField] private ButtonInput input = default;
        [SerializeField] private String nextScene;

        private void Start()
        {
            input.clickAsObservable
                .Subscribe()
                .AddTo(this);
        }
    }
}