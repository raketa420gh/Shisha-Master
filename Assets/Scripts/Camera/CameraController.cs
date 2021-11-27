using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Raketa420
{
   public class CameraController : MonoBehaviour
   {
      [SerializeField] private Camera mainCamera;
      [SerializeField] private Transform cameraFollowObject;
      [SerializeField] private float speed = 3f;

      private void Start()
      {
         InitializeComponents();
      }

      private void Update()
      {

      }

      private void InitializeComponents()
      {
         if (mainCamera == null)
         {
            mainCamera = FindObjectOfType<Camera>();
         }
      }
   }
}

