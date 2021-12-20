using UnityEngine;
using System.Collections.Generic;

namespace Raketa420
{
   public class ClientAI : MonoBehaviour
   {
      public ServicePlace GetNearbyTable()
      {
         return GetClosestTable(GetFreeTables());
      }

      public Master GetMaster()
      {
         var master = FindObjectOfType<Master>();

         return master;
      }

      public Transform GetExitFromBar()
      {
         var exitFromBar = FindObjectOfType<ExitFromBarZone>();
         var exitFromBarPosition = exitFromBar.transform;

         return exitFromBarPosition;
      }

      public ServicePoint GetServicePoint(ServicePlace servicePlace)
      {
         var servicePoint = servicePlace.GetComponentInChildren<ServicePoint>();

         if (servicePoint != null)
         {
            return servicePoint;
         }
         else
         {
            Debug.LogError($"Точка обслуживания стола {gameObject.name} не найдена");
            return null;
         }
      }

      private ServicePlace GetClosestTable(ServicePlace[] tables)
      {
         ServicePlace servicePlaceNearby = null;
         var minDistance = Mathf.Infinity;
         var currentPosition = transform.position;

         foreach (ServicePlace table in tables)
         {
            float distance = Vector3.Distance(table.transform.position, currentPosition);
            if (distance < minDistance)
            {
               servicePlaceNearby = table;
               minDistance = distance;
            }
         }

         return servicePlaceNearby;
      }

      private Vector3[] GetFreeServicePointsPositions()
      {
         var allTablesList = FindAllGuestTables();
         var freeServicePointsPositionsList = new List<Vector3>();

         foreach (var table in allTablesList)
         {
            if (table.IsFree)
            {
               var position = table.GetServicePointPosition();
               freeServicePointsPositionsList.Add(position);
            }
         }

         return freeServicePointsPositionsList.ToArray();
      }

      private ServicePlace[] GetFreeTables()
      {
         var freeTablesList = new List<ServicePlace>();
         var allTables = FindAllGuestTables();

         foreach (var table in allTables)
         {
            if (table.IsFree)
            {
               freeTablesList.Add(table);
            }
         }

         return freeTablesList.ToArray();
      }

      private ServicePlace[] FindAllGuestTables()
      {
         var tables = FindObjectsOfType<ServicePlace>();
         var allTablesList = new List<ServicePlace>();

         foreach (var table in tables)
         {
            allTablesList.Add(table);
         }

         return allTablesList.ToArray();
      }
   }
}
