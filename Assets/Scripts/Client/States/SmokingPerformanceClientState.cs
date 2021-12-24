using UnityEngine;

namespace Raketa420
{
    public class SmokingPerformanceClientState : ClientState
    {
        private float timer;
        private float processTime = 45f;
        
        public SmokingPerformanceClientState(Client client, ClientStateMachine stateMachine) : base(client, stateMachine)
        {
        }

        public override void Enter()
        {
            base.Enter();

            timer = 0f;
            client.Data.SetSmokingPerformanceStatus();
            client.Reaction.ReactPositive(10);
        }

        public override void LogicUpdate()
        {
            base.LogicUpdate();
            
            timer += Time.deltaTime;

            var timerNormalized = timer / processTime;
            client.StatusView.SetStatusFillerValue(timerNormalized);

            if (timer > processTime)
            {
                client.Reaction.ReactPositive(10);
                client.stateMachine.ChangeState(client.exitFromBarClientState);
            }
        }
    }
}