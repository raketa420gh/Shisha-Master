using UnityEngine;

namespace Raketa420
{
   public class ClientStateMachine : MonoBehaviour
   {
      public ClientState CurrentState { get; private set; }

      public void Initialize(ClientState startingState)
      {
         CurrentState = startingState;
         startingState.Enter();
      }

      public void ChangeState(ClientState newState)
      {
         CurrentState.Exit();
         CurrentState = newState;
         newState.Enter();
      }
   }
}

