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

         if (!master.Movement.MeshAgent.hasPath)
         {
            stateMachine.ChangeState(master.inactionState);
         }
      }
   }
}
