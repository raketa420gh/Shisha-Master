using UnityEngine;

namespace Raketa420
{
   public class WalkMasterState : MasterState
   {
      public WalkMasterState(Master master, MasterStateMachine stateMachine) : base(master, stateMachine)
      {
      }

      public override void Enter()
      {
         base.Enter();

         master.Bank.SetWalkStatus();
         master.Animation.SetWalkAnimation();
      }

      public override void LogicUpdate()
      {
         base.LogicUpdate();

         var joystickDirection = master.Input.Joystick.Direction;
         var moveDirection = new Vector3(joystickDirection.x, 0, joystickDirection.y);
         
         master.Movement.Move(moveDirection);
         master.Rotation.LookAt(moveDirection);
         
         if (!master.Input.IsJoystickDragged())
         {
            stateMachine.ChangeState(master.inactionState);
         }
      }
   }
}
