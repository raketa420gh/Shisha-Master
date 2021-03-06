using UnityEngine;

namespace Raketa420
{
   public class ExitFromBarClientState : ClientState
   {
      private float interactDistance = 0.5f;
      private Vector3 exitFromBarPosition;

      public ExitFromBarClientState(Client client, ClientStateMachine stateMachine) : base(client, stateMachine)
      {
      }

      public override void Enter()
      {
         base.Enter();
         client.Data.SetExitFromBarStatus();
         client.Animation.SetWalkingAnimation();
         client.Data.ReleaseCurrentUsingTable();
         client.Movement.AiPath.enabled = true;

         exitFromBarPosition = client.AI.GetExitFromBar().position;
         client.Movement.MoveTo(exitFromBarPosition);
      }

      public override void LogicUpdate()
      {
         base.LogicUpdate();

         if (Vector3.Distance(client.transform.position, exitFromBarPosition) < interactDistance)
         {
            client.DestroySelf();
         }
      }
   }
}
