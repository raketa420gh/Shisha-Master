using UnityEngine;
using System.Linq;

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

         Debug.LogError($"Точка обслуживания стола {gameObject.name} не найдена");
         return null;
      }

      private ServicePlace GetClosestTable(ServicePlace[] tables)
      {
         ServicePlace servicePlaceNearby = null;
         var minDistance = Mathf.Infinity;
         var currentPosition = transform.position;

         foreach (ServicePlace table in tables)
         {
            var distance = Vector3.Distance(table.transform.position, currentPosition);
            
            if (distance < minDistance)
            {
               servicePlaceNearby = table;
               minDistance = distance;
            }
         }

         return servicePlaceNearby;
      }

      private ServicePlace[] GetFreeTables()
      {
         var allTables = GetAllGuestTables();

         return allTables.Where(table => table.IsFree).ToArray();
      }

      private ServicePlace[] GetAllGuestTables()
      {
         var tables = FindObjectsOfType<ServicePlace>();

         return tables.ToArray();
      }
   }
}
