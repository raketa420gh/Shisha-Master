using UnityEngine;

namespace Raketa420
{
   public class InactionClientState : ClientState
   {      
      public InactionClientState(Client client, ClientStateMachine stateMachine) : base(client, stateMachine)
      {
      }
      
      private float timer = 0f;
      private float waitingTime = 1f;

      public override void Enter()
      {
         base.Enter();

         timer = 0f;
         client.Data.SetInactionStatus();
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
            client.stateMachine.ChangeState(client.findPlaceState);
         }
      }
   }
}
