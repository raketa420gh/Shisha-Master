namespace Raketa420
{
   public abstract class ClientState
   {
      protected Client client;
      protected ClientStateMachine stateMachine;

      protected ClientState(Client client, ClientStateMachine stateMachine)
      {
         this.client = client;
         this.stateMachine = stateMachine;
      }

      public virtual void Enter()
      {
         client.StatusView.SetStatusFillerValue(0);
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
