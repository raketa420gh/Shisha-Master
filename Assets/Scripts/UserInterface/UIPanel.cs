using UnityEngine;

namespace Raketa420
{
    public class UIPanel : MonoBehaviour
    {
        private bool isActive;
        
        public void SetActive(bool isActive)
        {
            gameObject.SetActive(isActive);
            this.isActive = isActive;
        }
    }
}
