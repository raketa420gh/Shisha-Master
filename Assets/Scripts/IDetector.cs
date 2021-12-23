using UnityEngine;

namespace Raketa420
{
    public delegate void ObjectDetectedHandler(GameObject source, GameObject detectedObject);
    
    public interface IDetector
    {
        event ObjectDetectedHandler OnGameObjectDetected;
        event ObjectDetectedHandler OnGameObjectDetectionReleased;

        void Detect(IDetectableObject detectableObject);
        void Detect(GameObject detectedObject);
        void ReleaseDetection(IDetectableObject detectableObject);
        void ReleaseDetection(GameObject detectedObject);
    }
}