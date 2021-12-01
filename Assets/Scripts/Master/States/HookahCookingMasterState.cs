using UnityEngine;

namespace Raketa420
{
   public class HookahCookingMasterState : MasterState
   {
      public HookahCookingMasterState(Master master, MasterStateMachine stateMachine) : base(master, stateMachine)
      {
      }

      public override void Enter()
      {
         base.Enter();

         //master.Bank.SetWalkStatus();
         master.Animation.SetIdleAnimation();
      }

      public override void LogicUpdate()
      {
         base.LogicUpdate();
      }
   }
}

