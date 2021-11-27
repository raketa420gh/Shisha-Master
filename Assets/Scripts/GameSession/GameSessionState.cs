using UnityEngine;

namespace Raketa420
{
   public abstract class GameSessionState
   {
      protected GameSession gameSession;
      protected GameSessionStateMachine stateMachine;
      protected GameSessionState(GameSession gameSession, GameSessionStateMachine stateMachine)
      {
         this.gameSession = gameSession;
         this.stateMachine = stateMachine;
      }

      public virtual void Enter()
      {
         Debug.Log($"GameSession {stateMachine.CurrentState} state entered");
      }

      public virtual void HandleInput()
      {
      }

      public virtual void LogicUpdate()
      {
      }

      public virtual void Exit()
      {
      }
   }
}
