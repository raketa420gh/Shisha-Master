using UnityEngine;

namespace Raketa420
{
    public class DetectableObjectReactionColor : MonoBehaviour
    {
        [SerializeField] private Color colorReaction = Color.red;

        private IDetectableObject detectableObject;
        private Color colorByDefault;
        private Material material;
        private static readonly int shaderColor = Shader.PropertyToID("_Color");

        private void Awake()
        {
            detectableObject = GetComponent<IDetectableObject>();

            var myRenderer = GetComponentInChildren<Renderer>();

            material = myRenderer.material;
            colorByDefault = material.color;
        }

        private void OnEnable()
        {
            detectableObject.OnGameObjectDetected += OnGameObjectDetected;
            detectableObject.OnGameObjectDetectionReleased += OnGameObjectDetectionReleased;
        }

        private void OnDisable()
        {
            detectableObject.OnGameObjectDetected -= OnGameObjectDetected;
            detectableObject.OnGameObjectDetectionReleased -= OnGameObjectDetectionReleased;
        }

        private void SetColor(Color color)
        {
            material.SetColor(shaderColor, color);
        }

        private void OnGameObjectDetected(GameObject source, GameObject detectedObject)
        {
            SetColor(colorReaction);
        }
        
        private void OnGameObjectDetectionReleased(GameObject source, GameObject detectedObject)
        {
            SetColor(colorByDefault);
        }
    }
}