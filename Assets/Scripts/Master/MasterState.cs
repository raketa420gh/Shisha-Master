namespace Raketa420
{
   public abstract class MasterState
   {
      protected Master master;
      protected MasterStateMachine stateMachine;

      protected MasterState(Master master, MasterStateMachine stateMachine)
      {
         this.master = master;
         this.stateMachine = stateMachine;
      }

      public virtual void Enter()
      {
      }

      public virtual void HandleInput()
      {
      }

      public virtual void LogicUpdate()
      {
      }

      public virtual void Exit()
      {
      }
   }
}
