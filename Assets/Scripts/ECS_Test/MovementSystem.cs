using Leopotam.Ecs;

namespace Raketa420.ECS
{
   sealed class MovementSystem : IEcsRunSystem
   {
      private readonly EcsWorld world = null;
      private readonly EcsFilter<ModelComponent, MovableComponent, PositionComponent> movableFilter = null;

      public void Run()
      {

      }
   }
}
