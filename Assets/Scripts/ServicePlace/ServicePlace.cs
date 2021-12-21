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
      private SitPlace[] sitPlaces;
      private ServicePlaceStatusView statusView;
      
      public bool IsFree => isFree;
      public bool HaveHookah => haveHookah;
      public SitPlace[] SitPlaces => sitPlaces;
      
      public void Initialize()
      {
         statusView = GetComponent<ServicePlaceStatusView>();
         servicePoint = GetComponentInChildren<ServicePoint>();
         sitPlaces = GetComponentsInChildren<SitPlace>();
         tableTrigger = (TableTrigger) GetComponentInChildren(typeof(TableTrigger));
         
         SetFree(true);
         SetHaveHookah(false);
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

      public void SetHaveHookah(bool have)
      {
         haveHookah = have;
      }
   }
}
