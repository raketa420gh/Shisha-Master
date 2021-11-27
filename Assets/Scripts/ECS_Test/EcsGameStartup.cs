using Leopotam.Ecs;
using Voody.UniLeo;
using UnityEngine;

namespace Raketa420.ECS
{
   public class EcsGameStartup : MonoBehaviour
   {
      private EcsWorld world;
      private EcsSystems systems;

      private void Start()
      {
         world = new EcsWorld();
         systems = new EcsSystems(world);

         systems.ConvertScene();

         AddInjections();
         AddOneFrames();
         AddSystems();

         systems.Init();
      }

      private void Update()
      {
         systems.Run();
      }

      private void OnDestroy()
      {
         if (systems == null)
         {
            return;
         }

         systems.Destroy();
         systems = null;
         world.Destroy();
         world = null;
      }

      private void AddSystems()
      {

      }

      private void AddInjections()
      {

      }

      private void AddOneFrames()
      {

      }
   }
}