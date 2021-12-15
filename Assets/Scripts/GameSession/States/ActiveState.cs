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
         gameSession.UserInterface.EnableDropItemButton(false);

         var randomPeriod = Random.Range(5f, 20f);
         gameSession.Spawner.StartSpawningClients(gameSession.Data.ClientStartPosition, 10, randomPeriod);
      }
   }
}
