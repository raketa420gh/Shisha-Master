using UnityEngine;

namespace Raketa420
{
   public class GameSessionStateMachine : MonoBehaviour
   {
      public GameSessionState CurrentState { get; private set; }

      public void Initialize(GameSessionState startingState)
      {
         CurrentState = startingState;
         startingState.Enter();
      }

      public void ChangeState(GameSessionState newState)
      {
         CurrentState.Exit();
         CurrentState = newState;
         newState.Enter();
      }
   }
}

