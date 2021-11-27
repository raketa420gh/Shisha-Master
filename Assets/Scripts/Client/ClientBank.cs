using UnityEngine;
using System;

namespace Raketa420
{
   public class ClientBank : MonoBehaviour
   {
      [SerializeField] private StatusData inactionStatusData;
      [SerializeField] private StatusData findPlaceStatusData;
      [SerializeField] private StatusData waitingForOrderAcceptanceStatusData;
      [SerializeField] private StatusData exitFromBarStatusData;
      private StatusData currentStatus;
      private Table currentUsingTable;

      public event Action<StatusData> OnStatusChanged;
      public static event Action<Table> OnTableReleased;

      public StatusData CurrentStatus => currentStatus;
      public Table CurrentUsingTable => currentUsingTable;

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

      public void SetExitFromBarStatus()
      {
         SetStatus(exitFromBarStatusData);
      }

      public void SetCurrentUsingTable(Table table)
      {
         currentUsingTable = table;
      }

      public void ReleaseCurrentUsingTable()
      {
         if (currentUsingTable != null)
         {
            OnTableReleased?.Invoke(currentUsingTable);
         }

         currentUsingTable = null;
      }

      private void SetStatus(StatusData status)
      {
         currentStatus = status;

         OnStatusChanged?.Invoke(status);
      }
   }
}