using UnityEngine;
using UnityEngine.EventSystems;

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
         
         if (!master.Input.IsEnabled)
            return;

         var moveDirection = 
            new Vector3(master.Input.GetInputDirection().x, 0, master.Input.GetInputDirection().y);
         
         master.Movement.Move(moveDirection);
         
         if (!master.Input.IsJoystickDragged())
         {
            stateMachine.ChangeState(master.inactionState);
         }
         else
         {
            master.Rotation.LookAt(moveDirection);
         }
      }
   }
}
