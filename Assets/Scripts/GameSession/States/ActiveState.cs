using UnityEditor.AI;
using UnityEngine;

namespace Raketa420
{
   public class ActiveState : GameSessionState
   {
      public ActiveState(GameSession gameSession, GameSessionStateMachine stateMachine) : base(gameSession, stateMachine)
      {
      }

      public override void Enter()
      {
         base.Enter();

         gameSession.Input.Enable(true);
         NavMeshBuilder.ClearAllNavMeshes();
         NavMeshBuilder.BuildNavMesh();

         var randomPeriod = Random.Range(5f, 20f);
         gameSession.Spawner.StartSpawningClients(gameSession.Data.ClientStartPosition, 10, randomPeriod);
      }

      public override void LogicUpdate()
      {
         base.LogicUpdate();
      }
   }
}
