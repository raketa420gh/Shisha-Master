using UnityEngine;
using System;
using Random = UnityEngine.Random;

namespace Raketa420
{
   [RequireComponent(typeof(ClientData))]
   [RequireComponent(typeof(ClientAnimation))]
   [RequireComponent(typeof(ClientMovement))]
   [RequireComponent(typeof(ClientRotation))]
   [RequireComponent(typeof(ClientReaction))]
   [RequireComponent(typeof(ClientStatusView))]
   [RequireComponent(typeof(ClientStateMachine))]
   [RequireComponent(typeof(ClientAI))]

   public class Client : MonoBehaviour
   {
      public ClientStateMachine stateMachine;
      public InactionClientState inactionState;
      public FindPlaceClientState findPlaceState;
      public WaitingOrderAcceptanceClientState waitingOrderAcceptanceClientState;
      public WaitingOrderClientState waitingOrderClientState;
      public WaitSecondTimeClientState waitSecondTimeState;
      public SmokingPerformanceClientState smokingPerformanceClientState;
      public ExitFromBarClientState exitFromBarClientState;

      private ClientData data;
      private ClientAnimation animation;
      private ClientMovement movement;
      private ClientRotation rotation;
      private ClientReaction reaction;
      private ClientStatusView statusView;
      private ClientAI ai;

      public static event Action<Client, ServicePlace> OnTableTaked;

      public ClientData Data => data;
      public ClientAnimation Animation => animation;
      public ClientMovement Movement => movement;
      public ClientRotation Rotation => rotation;
      public ClientReaction Reaction => reaction;
      public ClientStatusView StatusView => statusView;
      public ClientAI AI => ai;

      private void Start()
      {
         Initialize();
      }

      private void Update()
      {
         stateMachine.CurrentState.LogicUpdate();
      }

      public void TakeTable(Client client, ServicePlace servicePlace)
      {
         data.SetCurrentUsingTable(servicePlace);

         OnTableTaked?.Invoke(this, servicePlace);
      }

      public SitPlace GetSitPlace()
      {
         if (!data.CurrentSitPlace)
         {
            var sitPlaces = data.CurrentUsingServicePlace.SitPlaces;
            var randomSitPlacesIndex = Random.Range(0, data.CurrentUsingServicePlace.SitPlaces.Length);
            
            return sitPlaces[randomSitPlacesIndex];
         }

         Debug.LogError($"Sit Places Not Found");
         return null;
      }

      public void DestroySelf()
      {
         Destroy(gameObject);
      }

      private void Initialize()
      {
         data = GetComponent<ClientData>();
         animation = GetComponent<ClientAnimation>();
         movement = GetComponent<ClientMovement>();
         rotation = GetComponent<ClientRotation>();
         reaction = GetComponent<ClientReaction>();
         statusView = GetComponent<ClientStatusView>();
         ai = GetComponent<ClientAI>();

         movement.Initialize();
         statusView.Initialize();

         InitializeStateMachine();
      }

      private void InitializeStateMachine()
      {
         stateMachine = GetComponent<ClientStateMachine>();
         inactionState = new InactionClientState(this, stateMachine);
         findPlaceState = new FindPlaceClientState(this, stateMachine);
         waitingOrderAcceptanceClientState = new WaitingOrderAcceptanceClientState(this, stateMachine);
         waitingOrderClientState = new WaitingOrderClientState(this, stateMachine);
         waitSecondTimeState = new WaitSecondTimeClientState(this, stateMachine);
         smokingPerformanceClientState = new SmokingPerformanceClientState(this, stateMachine);
         exitFromBarClientState = new ExitFromBarClientState(this, stateMachine);

         stateMachine.Initialize(inactionState);
      }
   }
}
