using System;
using UnityEngine;

namespace Raketa420
{
   public class UserInput : MonoBehaviour
   {
      [SerializeField] private LayerMask whatCanBeClickedOn;
      private bool isEnabled = false;

      public static event Action<Vector3> OnClicked;
      public static event Action OnPressedM;
      public static event Action OnPressedC;

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

         if (Input.GetKeyDown(KeyCode.M))
         {
            OnPressedM?.Invoke();
         }

         if (Input.GetKeyDown(KeyCode.C))
         {
            OnPressedC?.Invoke();
         }
      }

      public void Enable(bool isEnabled)
      {
         this.isEnabled = isEnabled;
      }
   }
}

