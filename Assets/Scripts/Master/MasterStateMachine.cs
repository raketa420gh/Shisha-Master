using UnityEngine;

namespace Raketa420
{
   public class MasterStateMachine : MonoBehaviour
   {
      public MasterState CurrentState { get; private set; }

      public void Initialize(MasterState startingState)
      {
         CurrentState = startingState;
         startingState.Enter();
      }

      public void ChangeState(MasterState newState)
      {
         CurrentState.Exit();
         CurrentState = newState;
         newState.Enter();
      }
   }
}

