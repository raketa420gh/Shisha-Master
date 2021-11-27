using UnityEngine;
using UnityEngine.AI;

namespace Raketa420
{
   [RequireComponent(typeof(NavMeshAgent))]

   public class MasterMovement : MonoBehaviour
   {
      private NavMeshAgent meshAgent;

      public NavMeshAgent MeshAgent => meshAgent;

      private void OnEnable()
      {
         UserInput.OnClicked += UserInputOnClicked;
      }

      private void OnDisable()
      {
         UserInput.OnClicked += UserInputOnClicked;
      }

      private void Awake()
      {
         InitializeComponents();
      }

      private void InitializeComponents()
      {
         meshAgent = GetComponent<NavMeshAgent>();
      }

      private void MoveTo(Vector3 point)
      {
         meshAgent.enabled = true;
         meshAgent.SetDestination(point);
      }

      private void UserInputOnClicked(Vector3 point)
      {
         MoveTo(point);
      }
   }
}
