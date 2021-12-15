using System;
using UnityEngine;

namespace Raketa420
{
    [RequireComponent(typeof(Rigidbody))]

    public class LiftedItem : MonoBehaviour
    {
        private Rigidbody selfRigidbody;
        private Transform selfTransform;

        private void Awake()
        {
            selfRigidbody = GetComponent<Rigidbody>();
            selfTransform = transform;
        }

        public void Lift(Transform parent, Transform hand)
        {
            selfRigidbody.isKinematic = true;
            selfTransform.position = hand.position;
            selfTransform.SetParent(parent);
        }

        public void Drop()
        {
            selfRigidbody.isKinematic = false;
            var parent = FindObjectOfType<ParentForObjects>();
            selfTransform.SetParent(parent.transform);
        }
    }
}