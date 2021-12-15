using UnityEngine;

namespace Raketa420
{
   public class GameplayState : GameState
   {
      public GameplayState(Game game, GameStateMachine stateMachine) : base(game, stateMachine)
      {
      }

      public override void Enter()
      {
         base.Enter();

         game.Input.Enable(true);
         game.UI.EnableInteractionItemButton(false);

         var randomPeriod = Random.Range(5f, 20f);
         game.Spawner.StartSpawningClients(game.Data.ClientStartPosition, 10, randomPeriod);
      }
   }
}
