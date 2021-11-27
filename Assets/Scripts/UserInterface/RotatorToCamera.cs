using UnityEngine;

namespace Raketa420
{

   public class RotatorToCamera : MonoBehaviour
   {
      private Canvas canvas;
      private Quaternion cameraRotation;

      private void Awake()
      {
         if (!canvas)
         {
            canvas = GetComponent<Canvas>();
         }
      }

      private void Start()
      {
         cameraRotation = Camera.main.transform.rotation;
         canvas.worldCamera = Camera.main;
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