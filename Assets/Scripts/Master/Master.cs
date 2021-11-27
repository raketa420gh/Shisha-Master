using UnityEngine;

namespace Raketa420
{
   [RequireComponent(typeof(MasterBank))]
   [RequireComponent(typeof(MasterAnimation))]
   [RequireComponent(typeof(MasterMovement))]
   [RequireComponent(typeof(MasterStatusView))]
   [RequireComponent(typeof(MasterStateMachine))]

   public class Master : MonoBehaviour
   {
      public MasterStateMachine stateMachine;
      public InactionMasterState inactionState;
      public WalkMasterState walkState;

      private MasterBank bank;
      private MasterAnimation animation;
      private MasterMovement movement;
      private MasterStatusView statusView;

      public MasterBank Bank => bank;
      public MasterAnimation Animation => animation;
      public MasterMovement Movement => movement;
      public MasterStatusView StatusView => statusView;

      private void Awake()
      {
         InitializeSelfComponents();
      }

      private void Start()
      {
         InitializeStateMachine();
         InitializeOtherComponents();
      }

      private void Update()
      {
         stateMachine.CurrentState.LogicUpdate();
      }

      private void InitializeSelfComponents()
      {
         bank = GetComponent<MasterBank>();
         animation = GetComponent<MasterAnimation>();
         movement = GetComponent<MasterMovement>();
         statusView = GetComponent<MasterStatusView>();
      }

      private void InitializeOtherComponents()
      {
      }

      private void InitializeStateMachine()
      {
         stateMachine = GetComponent<MasterStateMachine>();
         inactionState = new InactionMasterState(this, stateMachine);
         walkState = new WalkMasterState(this, stateMachine);

         stateMachine.Initialize(inactionState);
      }

      private void OnMasterSpawned()
      {
      }
   }
}




