using UnityEngine;
using System;

namespace Raketa420
{
   public class ClientData : MonoBehaviour
   {
      [SerializeField] private StatusData inactionStatusData;
      [SerializeField] private StatusData findPlaceStatusData;
      [SerializeField] private StatusData waitingForOrderAcceptanceStatusData;
      [SerializeField] private StatusData makingAnOrderStatusData;
      [SerializeField] private StatusData smokingPerformanceStatusData;
      [SerializeField] private StatusData exitFromBarStatusData;
      private StatusData currentStatus;
      private ServicePlace currentUsingServicePlace;
      private SitPlace currentSitPlace;

      public event Action<StatusData> OnStatusChanged;
      public static event Action<ServicePlace> OnTableReleased;
      
      public ServicePlace CurrentUsingServicePlace => currentUsingServicePlace;
      public SitPlace CurrentSitPlace => currentSitPlace;

      public void SetInactionStatus()
      {
         SetStatus(inactionStatusData);
      }

      public void SetFindingPlaceStatus()
      {
         SetStatus(findPlaceStatusData);
      }

      public void SetWaitingOrderAcceptanceStatus()
      {
         SetStatus(waitingForOrderAcceptanceStatusData);
      }

      public void SetWaitingOrderStatus()
      {
         SetStatus(makingAnOrderStatusData);
      }
      
      public void SetSmokingPerformanceStatus()
      {
         SetStatus(smokingPerformanceStatusData);
      }

      public void SetExitFromBarStatus()
      {
         SetStatus(exitFromBarStatusData);
      }

      public void SetCurrentUsingTable(ServicePlace servicePlace)
      {
         currentUsingServicePlace = servicePlace;
      }

      public void ReleaseCurrentUsingTable()
      {
         if (currentUsingServicePlace != null)
         {
            OnTableReleased?.Invoke(currentUsingServicePlace);
         }

         currentUsingServicePlace = null;
      }

      public void SetCurrentSitPlace(SitPlace sitPlace)
      {
         currentSitPlace = sitPlace;
      }

      private void SetStatus(StatusData status)
      {
         currentStatus = status;

         OnStatusChanged?.Invoke(status);
      }
   }
}