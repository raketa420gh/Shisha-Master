using UnityEngine;

namespace Raketa420
{
   public class FindPlaceClientState : ClientState
   {
      private float timer = 0f;
      private float interactDistance = 0.5f;

      public FindPlaceClientState(Client client, ClientStateMachine stateMachine) : base(client, stateMachine)
      {
      }

      public override void Enter()
      {
         base.Enter();

         timer = 0f;
         client.Bank.SetFindingPlaceStatus();
         client.Animation.SetWalkingAnimation();

         var nearbyTable = client.AI.GetNearbyTable();

         if (!nearbyTable)
         {
            client.stateMachine.ChangeState(client.exitFromBarClientState);

            return;
         }

         var servicePoint = client.AI.GetServicePoint(nearbyTable);
         var position = servicePoint.transform.position;
         client.Movement.MoveTo(position);
         client.TakeTable(client, nearbyTable);
      }

      public override void LogicUpdate()
      {
         base.LogicUpdate();

         if (Vector3.Distance(client.transform.position, client.Movement.AiPath.destination) < interactDistance)
         {
            client.stateMachine.ChangeState(client.waitingForOrderAcceptanceClientState);
         }
      }

      public override void Exit()
      {
         base.Exit();
      }
   }
}
