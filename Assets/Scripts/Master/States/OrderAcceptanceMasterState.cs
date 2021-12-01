using UnityEngine;

namespace Raketa420
{
   public class OrderAcceptanceMasterState : MasterState
   {
      public OrderAcceptanceMasterState(Master master, MasterStateMachine stateMachine) : base(master, stateMachine)
      {
      }

      public override void Enter()
      {
         base.Enter();

         master.Bank.SetOrderAcceptanceStatus();
         master.Animation.SetIdleAnimation();
      }

      public override void LogicUpdate()
      {
         base.LogicUpdate();
      }
   }
}

