using UnityEngine;
using System;

namespace Raketa420
{
   [RequireComponent(typeof(ClientBank))]
   [RequireComponent(typeof(ClientAnimation))]
   [RequireComponent(typeof(ClientMovement))]
   [RequireComponent(typeof(ClientStatusView))]
   [RequireComponent(typeof(ClientStateMachine))]
   [RequireComponent(typeof(ClientAI))]

   public class Client : MonoBehaviour
   {
      public ClientStateMachine stateMachine;
      public InactionClientState inactionState;
      public FindPlaceClientState findPlaceState;
      public WaitingForOrderAcceptanceClientState waitingForOrderAcceptanceClientState;
      public MakingAnOrderClientState makingAnOrderClientState;
      public WaitSecondTimeClientState waitSecondTimeState;
      public ExitFromBarClientState exitFromBarClientState;

      private ClientBank bank;
      private ClientAnimation animation;
      private ClientMovement movement;
      private ClientStatusView statusView;
      private ClientAI ai;

      public static event Action<Client, Table> OnTableTaked;

      public ClientBank Bank => bank;
      public ClientAnimation Animation => animation;
      public ClientMovement Movement => movement;
      public ClientStatusView StatusView => statusView;
      public ClientAI AI => ai;

      private void Awake()
      {
         InitializeSelfComponents();
      }

      private void Start()
      {
         InitializeStateMachine();
      }

      private void Update()
      {
         stateMachine.CurrentState.LogicUpdate();
      }

      public void TakeTable(Client client, Table table)
      {
         bank.SetCurrentUsingTable(table);

         OnTableTaked?.Invoke(this, table);
      }

      public void DestroySelf()
      {
         Destroy(gameObject);
      }

      private void InitializeSelfComponents()
      {
         bank = GetComponent<ClientBank>();
         animation = GetComponent<ClientAnimation>();
         movement = GetComponent<ClientMovement>();
         statusView = GetComponent<ClientStatusView>();
         ai = GetComponent<ClientAI>();
      }

      private void InitializeStateMachine()
      {
         stateMachine = GetComponent<ClientStateMachine>();
         inactionState = new InactionClientState(this, stateMachine);
         findPlaceState = new FindPlaceClientState(this, stateMachine);
         waitingForOrderAcceptanceClientState = new WaitingForOrderAcceptanceClientState(this, stateMachine);
         makingAnOrderClientState = new MakingAnOrderClientState(this, stateMachine);
         waitSecondTimeState = new WaitSecondTimeClientState(this, stateMachine);
         exitFromBarClientState = new ExitFromBarClientState(this, stateMachine);

         stateMachine.Initialize(inactionState);
      }
   }
}
