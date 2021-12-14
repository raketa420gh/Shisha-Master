using UnityEngine;

namespace Raketa420
{
   public class RotatorToCamera : MonoBehaviour
   {
      private Camera mainCamera;
      private Canvas canvas;
      private Quaternion cameraRotation;

      private void Awake()
      {
         mainCamera = Camera.main;
         
         if (!canvas)
         {
            canvas = GetComponent<Canvas>();
         }
      }

      private void Start()
      {
         cameraRotation = mainCamera.transform.rotation;
         canvas.worldCamera = mainCamera;
      }

      void Update()
      {
         if (canvas.transform.rotation != cameraRotation)
         {
            canvas.gameObject.transform.rotation = cameraRotation;
         }
      }
   }
}