using UnityEngine;
using System;

namespace Raketa420
{
   public class CameraSizeUpZone : MonoBehaviour
   {
      public static event Action OnMasterEntered;
      public static event Action OnMasterLeft;

      private void OnTriggerEnter(Collider other)
      {
         if (other.GetComponent<Master>())
         {
            OnMasterEntered?.Invoke();
         }
      }

      private void OnTriggerExit(Collider other)
      {
         if (other.GetComponent<Master>())
         {
            OnMasterLeft?.Invoke();
         }
      }
   }
}

