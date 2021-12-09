using UnityEngine;
using System.Collections.Generic;

namespace Raketa420
{
   public class ClientAI : MonoBehaviour
   {
      public Table GetNearbyTable()
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

      public ServicePoint GetServicePoint(Table table)
      {
         var servicePoint = table.GetComponentInChildren<ServicePoint>();

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

      private Table GetClosestTable(Table[] tables)
      {
         Table tableNearby = null;
         var minDistance = Mathf.Infinity;
         var currentPosition = transform.position;

         foreach (Table table in tables)
         {
            float distance = Vector3.Distance(table.transform.position, currentPosition);
            if (distance < minDistance)
            {
               tableNearby = table;
               minDistance = distance;
            }
         }

         return tableNearby;
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

      private Table[] GetFreeTables()
      {
         var freeTablesList = new List<Table>();
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

      private Table[] FindAllGuestTables()
      {
         var tables = FindObjectsOfType<Table>();
         var allTablesList = new List<Table>();

         foreach (var table in tables)
         {
            allTablesList.Add(table);
         }

         return allTablesList.ToArray();
      }
   }
}
