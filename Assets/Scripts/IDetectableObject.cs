using UnityEngine;

namespace Raketa420
{
    public interface IDetectableObject
    {
        event ObjectDetectedHandler OnGameObjectDetected;
        event ObjectDetectedHandler OnGameObjectDetectionReleased;

        GameObject gameObject { get; }

        void Detected(GameObject detectionSource);
        void DetectionReleased(GameObject detectionSource);
    }
}