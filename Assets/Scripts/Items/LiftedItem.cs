using UnityEngine;

namespace Raketa420
{
    [RequireComponent(typeof(Rigidbody))]

    public class LiftedItem : MonoBehaviour, IDetectableObject
    {
        private Rigidbody selfRigidbody;
        private Transform selfTransform;
        private Transform parent;
        
        public event ObjectDetectedHandler OnGameObjectDetected;
        public event ObjectDetectedHandler OnGameObjectDetectionReleased;

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
            var rotationVector = Quaternion.Euler(Vector3.forward);
            selfTransform.rotation = rotationVector;
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
        
        public void Detected(GameObject detectionSource)
        {
            OnGameObjectDetected?.Invoke(detectionSource, gameObject);
        }

        public void DetectionReleased(GameObject detectionSource)
        {
            OnGameObjectDetectionReleased?.Invoke(detectionSource, gameObject);
        }
    }
}