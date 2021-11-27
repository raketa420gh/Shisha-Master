using UnityEngine;
using UnityEngine.AI;

namespace Raketa420
{
   [RequireComponent(typeof(NavMeshAgent))]

   public class ClientMovement : MonoBehaviour
   {
      private NavMeshAgent meshAgent;

      public NavMeshAgent MeshAgent => meshAgent;

      private void Awake()
      {
         InitializeComponents();
      }

      private void InitializeComponents()
      {
         meshAgent = GetComponent<NavMeshAgent>();
      }

      public void MoveTo(Vector3 point)
      {
         meshAgent.enabled = true;
         meshAgent.SetDestination(point);
      }
   }
}