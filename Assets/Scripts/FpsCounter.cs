using UnityEngine;

namespace Raketa420
{
    [RequireComponent(typeof(FpsView))]
    
    public class FpsCounter : MonoBehaviour
    {
        public float FPS { get; private set; }

        private void Update()
        {
            FPS = (int) (1f / Time.unscaledDeltaTime);
        }
    }
}
