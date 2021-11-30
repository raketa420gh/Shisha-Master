using UnityEngine;

namespace Raketa420
{
   public class WaitingForOrderAcceptanceClientState : ClientState
   {
      private float timer = 0f;
      private float waitingTime = 20f;
      private Master master;
      private float distanceToMaster = 0.5f;

      public WaitingForOrderAcceptanceClientState(Client client, ClientStateMachine stateMachine) : base(client, stateMachine)
      {
      }

      public override void Enter()
      {
         base.Enter();

         master = client.AI.GetMaster();

         timer = 0f;
         client.Bank.SetWaitingForOrderAcceptanceStatus();
         client.Animation.SetIdleAnimation();
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

         if (Vector3.Distance(master.transform.position, client.transform.position) < distanceToMaster)
         {
            client.stateMachine.ChangeState(client.makingAnOrderClientState);
         }
      }
   }
}
