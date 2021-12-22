using UnityEngine;

namespace Raketa420
{
   public class WaitingOrderAcceptanceClientState : ClientState
   {
      private Master master;
      private float timer;
      private float processTime = 15f;
      private float distanceToMaster = 1f;

      public WaitingOrderAcceptanceClientState(Client client, ClientStateMachine stateMachine) : base(client, stateMachine)
      {
      }

      public override void Enter()
      {
         base.Enter();

         master = client.AI.GetMaster();

         timer = 0f;
         client.Data.SetWaitingOrderAcceptanceStatus();
         Sit();
      }

      public override void LogicUpdate()
      {
         base.LogicUpdate();

         timer += Time.deltaTime;

         var timerNormalized = timer / processTime;
         client.StatusView.SetStatusFillerValue(timerNormalized);

         if (timer > processTime)
         {
            client.stateMachine.ChangeState(client.exitFromBarClientState);
         }

         if (Vector3.Distance(master.transform.position, client.transform.position) < distanceToMaster)
         {
            client.stateMachine.ChangeState(client.waitingOrderClientState);
         }
      }
      
      private void Sit()
      {
         client.Movement.AiPath.enabled = false;
         client.Animation.SetSittingAnimation();
         client.Data.SetCurrentSitPlace(client.GetSitPlace());

         var currentSitPlaceTransform = client.Data.CurrentSitPlace.transform;
         client.gameObject.transform.position = currentSitPlaceTransform.position;

         var lookDirection = currentSitPlaceTransform.forward;
         client.Rotation.LookAt(lookDirection);
      }
   }
}
