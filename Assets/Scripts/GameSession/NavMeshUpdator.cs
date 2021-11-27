using UnityEditor.AI;
using UnityEngine;

namespace Raketa420
{
   public class NavMeshUpdator : MonoBehaviour
   {
      [SerializeField] private float updatePeriod = 1f;

      private float timer = 0f;

      private void UpdateNavMeshBuilder()
      {
         NavMeshBuilder.ClearAllNavMeshes();
         NavMeshBuilder.BuildNavMesh();

      }

      private void Update()
      {
         timer += Time.deltaTime;

         if (timer > updatePeriod)
         {
            timer = 0f;

            UpdateNavMeshBuilder();
         }
      }
   }
}