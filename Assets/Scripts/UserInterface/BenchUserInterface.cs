using UnityEngine;

namespace Raketa420
{
    public class BenchUserInterface : MonoBehaviour
    {
        [SerializeField] private BenchCanvas canvas;

        public void SetActiveCanvas(bool isActive)
        {
            canvas.gameObject.SetActive(isActive);
        }
    }
}