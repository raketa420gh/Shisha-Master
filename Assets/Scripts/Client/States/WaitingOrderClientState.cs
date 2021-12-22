using UnityEngine;

namespace Raketa420
{
   public class WaitingOrderClientState : ClientState
   {
      private float timer;
      private float waitingTime = 30f;

      public WaitingOrderClientState(Client client, ClientStateMachine stateMachine) : base(client, stateMachine)
      {
      }

      public override void Enter()
      {
         base.Enter();

         timer = 0f;

         client.Data.SetWaitingOrderStatus();
      }

      public override void LogicUpdate()
      {
         base.LogicUpdate();

         timer += Time.deltaTime;

         var timerNormalized = timer / waitingTime;
         client.StatusView.SetStatusFillerValue(timerNormalized);

         if (timer > waitingTime)
         {
            client.stateMachine.ChangeState(client.exitFromBarClientState);
         }
         
         if (client.Data.CurrentUsingServicePlace.HaveHookah)
         {
            client.stateMachine.ChangeState(client.smokingPerformanceClientState);
         }
      }
   }
}
