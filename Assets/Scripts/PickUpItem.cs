using UnityEngine;

namespace Raketa420
{
    [RequireComponent(typeof(Rigidbody))]
    
    public class PickUpItem : MonoBehaviour
    {
        private Rigidbody selfRigidbody;

        private void Awake()
        {
            selfRigidbody = GetComponent<Rigidbody>();
        }
    }
}