using UnityEngine;

namespace Raketa420
{
    [RequireComponent(typeof(Rigidbody))]

    public class LiftedItem : MonoBehaviour
    {
        private Rigidbody selfRigidbody;
        private Transform selfTransform;
        private Transform parent;

        private void Awake()
        {
            selfRigidbody = GetComponent<Rigidbody>();
            selfTransform = transform;
            parent = FindObjectOfType<ParentForObjects>().transform;
        }

        public void Lift(Transform parent, Transform hand)
        {
            selfRigidbody.isKinematic = true;
            selfTransform.position = hand.position;
            selfTransform.SetParent(parent);
        }

        public void Drop(Vector3 direction, float powerAmount = 0)
        {
            selfRigidbody.isKinematic = false;
            selfTransform.SetParent(parent);
            selfRigidbody.AddForce(direction * powerAmount, ForceMode.Impulse);
        }

        public void SetKinematic(bool isActive)
        {
            selfRigidbody.isKinematic = isActive;
        }
    }
}