using Leopotam.Ecs;
using UnityEngine;

namespace Raketa420.ECS
{
   sealed class PlayerInputSystem : IEcsRunSystem
   {
      private readonly EcsWorld world = null;
      private readonly EcsFilter<PlayerTag, PositionComponent, CameraComponent> playerPositionFilter = null;

      private LayerMask groundMask = LayerMask.GetMask("Ground");

      public void Run()
      {
         foreach (var i in playerPositionFilter)
         {
            ref var positionComponent = ref playerPositionFilter.Get2(i);
            ref var cameraComponent = ref playerPositionFilter.Get3(i);
            ref var position = ref positionComponent.Position;
            ref var camera = ref cameraComponent.Camera;

            if (Input.GetMouseButton(0))
            {
               RaycastHit hit;
               Ray ray = camera.ScreenPointToRay(Input.mousePosition);

               if (Physics.Raycast(ray, out hit))
               {
                  Transform objectHit = hit.transform;

                  if (objectHit.gameObject.layer == groundMask)
                  {
                     position = objectHit.position;
                  }
               }
            }
         }
      }
   }
}