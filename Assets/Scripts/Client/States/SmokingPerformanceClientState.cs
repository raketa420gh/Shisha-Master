using System.Runtime.InteropServices;

namespace Raketa420
{
    public class SmokingPerformanceClientState : ClientState
    {
        public SmokingPerformanceClientState(Client client, ClientStateMachine stateMachine) : base(client, stateMachine)
        {
        }

        public override void Enter()
        {
            base.Enter();
            client.Data.SetSmokingPerformanceStatus();
            Sit();
        }

        public override void Exit()
        {
            base.Exit();
        }

        private void Sit()
        {
            client.Movement.enabled = false;
            client.Animation.SetSittingAnimation();
            client.Data.SetCurrentSitPlace(client.GetSitPlace());
            client.gameObject.transform.position = client.Data.CurrentSitPlace.transform.position;
        }
    }
}