using UnityEngine;
using Pathfinding;

namespace Raketa420
{
   [RequireComponent(typeof(Seeker))]
   [RequireComponent(typeof(AIPath))]

   public class ClientMovement : MonoBehaviour
   {
      private Seeker seeker;
      private AIPath aiPath;

      public AIPath AiPath => aiPath;

      private void Awake()
      {
         InitializeComponents();
      }

      private void InitializeComponents()
      {
         seeker = GetComponent<Seeker>();
         aiPath = GetComponent<AIPath>();
      }

      public void MoveTo(Vector3 point)
      {
         aiPath.destination = point;
      }
   }
}