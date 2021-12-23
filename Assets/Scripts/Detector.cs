using System.Collections.Generic;
using UnityEngine;

namespace Raketa420
{
    public class Detector : MonoBehaviour, IDetector
    {
        public event ObjectDetectedHandler OnGameObjectDetected;
        public event ObjectDetectedHandler OnGameObjectDetectionReleased;

        public GameObject[] detectedObjects => detectedObjectsList.ToArray();
        
        private List<GameObject> detectedObjectsList = new List<GameObject>();
            
        public void Detect(IDetectableObject detectableObject)
        {
            if (!detectedObjectsList.Contains(detectableObject.gameObject))
            {
                detectableObject.Detected(gameObject);
                detectedObjectsList.Add(detectableObject.gameObject);
                
                OnGameObjectDetected?.Invoke(gameObject, detectableObject.gameObject);
            }
        }

        public void Detect(GameObject detectedObject)
        {
            if (!detectedObjectsList.Contains(detectedObject))
            {
                detectedObjectsList.Add(detectedObject);
                
                OnGameObjectDetected?.Invoke(gameObject, detectedObject);
            }
        }

        public void ReleaseDetection(IDetectableObject detectableObject)
        {
            if (detectedObjectsList.Contains(detectableObject.gameObject))
            {
                detectableObject.DetectionReleased(gameObject);
                detectedObjectsList.Remove(detectableObject.gameObject);
                
                OnGameObjectDetectionReleased?.Invoke(gameObject, detectableObject.gameObject);
            }
        }

        public void ReleaseDetection(GameObject detectedObject)
        {
            if (detectedObjectsList.Contains(detectedObject))
            {
                detectedObjectsList.Remove(detectedObject);
                
                OnGameObjectDetectionReleased?.Invoke(gameObject, detectedObject);
            }
        }

        private void OnTriggerEnter(Collider other)
        {
            if (IsColliderDetectableObject(other, out var detectedObject))
                Detect(detectedObject);
        }
        private void OnTriggerExit(Collider other)
        {
            if (IsColliderDetectableObject(other, out var detectedObject))
                ReleaseDetection(detectedObject);
        }

        private bool IsColliderDetectableObject(Collider collider, out IDetectableObject detectedObject)
        {
            detectedObject = collider.GetComponentInParent<IDetectableObject>();

            return detectedObject != null;
        }
    }
}