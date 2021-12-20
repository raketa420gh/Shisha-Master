using UnityEngine;
using System;

namespace Raketa420
{
   public class ClientBank : MonoBehaviour
   {
      [SerializeField] private StatusData inactionStatusData;
      [SerializeField] private StatusData findPlaceStatusData;
      [SerializeField] private StatusData waitingForOrderAcceptanceStatusData;
      [SerializeField] private StatusData makingAnOrderStatusData;
      [SerializeField] private StatusData exitFromBarStatusData;
      private StatusData currentStatus;
      private ServicePlace _currentUsingServicePlace;

      public event Action<StatusData> OnStatusChanged;
      public static event Action<ServicePlace> OnTableReleased;

      public StatusData CurrentStatus => currentStatus;
      public ServicePlace CurrentUsingServicePlace => _currentUsingServicePlace;

      public void SetInactionStatus()
      {
         SetStatus(inactionStatusData);
      }

      public void SetFindingPlaceStatus()
      {
         SetStatus(findPlaceStatusData);
      }

      public void SetWaitingForOrderAcceptanceStatus()
      {
         SetStatus(waitingForOrderAcceptanceStatusData);
      }

      public void SetMakingAnOrderStatus()
      {
         SetStatus(makingAnOrderStatusData);
      }

      public void SetExitFromBarStatus()
      {
         SetStatus(exitFromBarStatusData);
      }

      public void SetCurrentUsingTable(ServicePlace servicePlace)
      {
         _currentUsingServicePlace = servicePlace;
      }

      public void ReleaseCurrentUsingTable()
      {
         if (_currentUsingServicePlace != null)
         {
            OnTableReleased?.Invoke(_currentUsingServicePlace);
         }

         _currentUsingServicePlace = null;
      }

      private void SetStatus(StatusData status)
      {
         currentStatus = status;

         OnStatusChanged?.Invoke(status);
      }
   }
}