using UnityEngine;

namespace Raketa420
{
   [RequireComponent(typeof(ServicePlaceStatusView))]

   public class ServicePlace : MonoBehaviour
   {
      private bool isFree = true;
      private bool haveHookah = false;
      private TableTrigger tableTrigger;
      private ServicePoint servicePoint;
      private ServicePlaceStatusView statusView;
      
      public bool IsFree => isFree;
      public TableTrigger TableTrigger => tableTrigger;
      
      public void Initialize()
      {
         statusView = GetComponent<ServicePlaceStatusView>();
         servicePoint = GetComponentInChildren<ServicePoint>();
         tableTrigger = (TableTrigger) GetComponentInChildren(typeof(TableTrigger));
         
         SetFree(true);
      }

      public Vector3 GetServicePointPosition()
      {
         return servicePoint.transform.position;
      }

      public void SetFree(bool isFree)
      {
         this.isFree = isFree;
         statusView.UdpateView(isFree);
      }
   }
}
