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
         game.UI.EnableHUD(true);
         game.UI.EnableMasterStatusPanel(true);
         game.UI.EnableInteractionItemButton(false);
         game.UI.EnableCraftButton(false);

         var randomPeriod = Random.Range(5f, 20f);
         game.Spawner.StartSpawningClients(game.Data.ClientStartPosition, 10, randomPeriod);
      }

      public override void Exit()
      {
         base.Exit();
         
         game.Input.Enable(false);
         game.UI.EnableHUD(false);
      }
   }
}
