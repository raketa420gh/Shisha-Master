using UnityEngine;

namespace Raketa420
{
   public class InactionMasterState : MasterState
   {
      public InactionMasterState(Master master, MasterStateMachine stateMachine) : base(master, stateMachine)
      {
      }

      public override void Enter()
      {
         base.Enter();

         master.Bank.SetInactionStatus();
         master.Animation.SetIdleAnimation();
      }

      public override void LogicUpdate()
      {
         base.LogicUpdate();
         
         //master.transform.forward = master.Input.Joystick.;
         
         if (master.Input.IsJoystickDragged())
         {
            stateMachine.ChangeState(master.walkState);
         }
      }
   }
}
