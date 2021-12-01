using UnityEngine;
using UnityEngine.UI;
using System;

namespace Raketa420
{
   public class MasterBank : MonoBehaviour
   {
      [SerializeField] private StatusData inactionStatusData;
      [SerializeField] private StatusData walkStatusData;
      [SerializeField] private StatusData orderAcceptanceStatusData;

      private StatusData currentStatus;

      public static event Action<StatusData> OnStatusChanged;

      public StatusData InactionStatusData => inactionStatusData;
      public StatusData WalkStatusData => walkStatusData;

      public void SetInactionStatus()
      {
         SetStatus(inactionStatusData);
      }

      public void SetWalkStatus()
      {
         SetStatus(walkStatusData);
      }

      public void SetOrderAcceptanceStatus()
      {
         SetStatus(orderAcceptanceStatusData);
      }

      private void SetStatus(StatusData status)
      {
         currentStatus = status;

         OnStatusChanged?.Invoke(status);
      }
   }
}