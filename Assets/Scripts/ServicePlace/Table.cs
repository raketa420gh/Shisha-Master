using UnityEngine;
using System;

namespace Raketa420
{
   [RequireComponent(typeof(TableStatusView))]

   public class Table : MonoBehaviour
   {
      private bool isFree = true;
      private ServicePoint servicePoint;
      private TableStatusView statusView;

      public ServicePoint ServicePoint => servicePoint;
      public bool IsFree => isFree;

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
         statusView = GetComponent<TableStatusView>();
         servicePoint = GetComponentInChildren<ServicePoint>();
      }

      private void OnClientTableTaked(Client client, Table table)
      {
         table.SetFree(false);
      }

      private void OnTableReleased(Table table)
      {
         table.SetFree(true);
      }
   }
}
