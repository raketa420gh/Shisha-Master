using System;
using UnityEngine;

namespace Raketa420
{
   public class UserInput : MonoBehaviour
   {
      [SerializeField] private LayerMask whatCanBeClickedOn;
      private bool isEnabled;

      public event Action<Vector3> OnClicked;

      private void Update()
      {
         if (!isEnabled)
         {
            return;
         }

         if (Input.GetMouseButton(0))
         {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hitInfo;

            if (Physics.Raycast(ray, out hitInfo, 100, whatCanBeClickedOn))
            {
               var point = new Vector3(hitInfo.point.x, hitInfo.point.y + 0.5f, hitInfo.point.z);
               OnClicked?.Invoke(point);
            }
         }
      }

      public void Enable(bool isActive)
      {
         isEnabled = isActive;
      }
   }
}

