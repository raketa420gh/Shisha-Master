using UnityEngine;
using System;
using System.Collections;

namespace Raketa420
{
   public class Spawner : MonoBehaviour
   {
      [SerializeField] private GameObject masterPrefab;
      [SerializeField] private GameObject clientPrefab;
      [SerializeField] private Transform charactersSpawnParent;

      public static event Action OnMasterCreated;
      public static event Action OnClientCreated;

      public void SpawnMaster(Vector3 position)
      {
         var master = FindObjectOfType<Master>();

         if (master)
         {
            Debug.LogError("Невозможно создать более 1-ого мастера");
            return;
         }

         Spawn(masterPrefab, position, Quaternion.identity, charactersSpawnParent);

         OnMasterCreated?.Invoke();
      }

      public void SpawnClient(Vector3 position)
      {
         Spawn(clientPrefab, position, Quaternion.identity, charactersSpawnParent);

         OnClientCreated?.Invoke();
      }

      public void StartSpawningClients(Vector3 position, int amount, float period)
      {
         if (amount < 0)
         {
            amount = 0;
            Debug.LogError($"Нельзя укзывать отрицательное кол-во объектов для спавна");
         }

         if (period < 0)
         {
            period = 0;
            Debug.LogError($"Нельзя укзывать отрицательно число времени переодичности спавна");
         }

         StartCoroutine(StartSpawningClientsRoutine(position, amount, period));
      }

      private void Spawn(GameObject prefab, Vector3 position, Quaternion rotation, Transform parent)
      {
         Instantiate(prefab, position, rotation, parent.transform);
      }

      private IEnumerator StartSpawningClientsRoutine(Vector3 position, int amount, float period)
      {
         while (true)
         {
            yield return new WaitForSeconds(period);

            SpawnClient(position);

            amount--;

            if (amount == 0)
            {
               yield break;
            }
         }
      }
   }
}

