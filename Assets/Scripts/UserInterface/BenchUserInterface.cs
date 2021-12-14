using System;
using UnityEngine;

namespace Raketa420
{
    public class BenchUserInterface : MonoBehaviour
    {
        [SerializeField] private BenchCanvas canvas;

        public BenchCanvas Canvas => canvas;

        public void Initialize()
        {
            canvas.Initialize();
        }

        public void SetActiveCanvas(bool isActive)
        {
            canvas.gameObject.SetActive(isActive);
        }
    }
}