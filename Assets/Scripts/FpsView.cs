using System;
using TMPro;
using UnityEngine;

namespace Raketa420
{
    public class FpsView : MonoBehaviour
    {
        [SerializeField] private TMP_Text label;
        private FpsCounter fpsCounter;

        private void Awake()
        {
            fpsCounter = GetComponent<FpsCounter>();
        }

        private void Update()
        {

            label.text = fpsCounter.FPS.ToString();
        }
    }
}