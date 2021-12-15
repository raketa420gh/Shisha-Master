using UnityEngine;

namespace Raketa420
{
   public class PauseState : GameState
   {
      public PauseState(Game game, GameStateMachine stateMachine) : base(game, stateMachine)
      {
      }

      public override void Enter()
      {
         SetActivePause(true);
      }

      public override void Exit()
      {
         SetActivePause(false);
      }

      private void SetActivePause(bool isActive)
      {
         if (isActive)
         {
            Time.timeScale = 0f;
         }
         else
         {
            Time.timeScale = 1f;
         }
      }
   }
}
