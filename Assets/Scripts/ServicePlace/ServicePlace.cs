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

      private void OnEnable()
      {
         Client.OnTableTaked += OnClientTableTaked;
         ClientBank.OnTableReleased += OnTableReleased;
      }

      private void OnDisable()
      {
         Client.OnTableTaked -= OnClientTableTaked;
         ClientBank.OnTableReleased -= OnTableReleased;
      }

      private void Awake()
      {
         InitialiazeSelfComponents();
      }

      private void Start()
      {
         SetFree(true);
      }

      public Vector3 GetServicePointPosition()
      {
         return servicePoint.transform.position;
      }

      private void SetFree(bool isFree)
      {
         this.isFree = isFree;
         statusView.UdpateView(isFree);
      }

      private void InitialiazeSelfComponents()
      {
         statusView = GetComponent<ServicePlaceStatusView>();
         servicePoint = GetComponentInChildren<ServicePoint>();
         tableTrigger = (TableTrigger) GetComponentInChildren(typeof(TableTrigger));
      }

      private void OnClientTableTaked(Client client, ServicePlace servicePlace)
      {
         servicePlace.SetFree(false);
      }

      private void OnTableReleased(ServicePlace servicePlace)
      {
         servicePlace.SetFree(true);
      }
   }
}
