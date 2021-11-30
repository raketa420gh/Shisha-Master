using UnityEngine;

namespace Raketa420
{
   public class MakingAnOrderClientState : ClientState
   {
      public MakingAnOrderClientState(Client client, ClientStateMachine stateMachine) : base(client, stateMachine)
      {
      }

      public override void Enter()
      {
         base.Enter();

         client.Bank.SetMakingAnOrderStatus();
         client.Animation.SetIdleAnimation();
      }

      public override void LogicUpdate()
      {
         base.LogicUpdate();


      }
   }
}
