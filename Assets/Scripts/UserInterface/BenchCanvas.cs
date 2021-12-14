using System;
using UnityEngine;

namespace Raketa420
{
    public class BenchCanvas : MonoBehaviour
    {
        public event Action OnClicked;

        public void Initialize()
        {
            var canvas = this;
        }

        public void ClickCraftButton()
        {
            OnClicked?.Invoke();
        }
    }
}