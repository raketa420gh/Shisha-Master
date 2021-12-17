using UnityEngine;

namespace Raketa420
{
   [RequireComponent(typeof(MasterBank))]
   [RequireComponent(typeof(MasterAnimation))]
   [RequireComponent(typeof(MasterMovement))]
   [RequireComponent(typeof(MasterRotation))]
   [RequireComponent(typeof(MasterStatusView))]
   [RequireComponent(typeof(MasterInteraction))]
   [RequireComponent(typeof(MasterStateMachine))]

   public class Master : MonoBehaviour
   {
      [SerializeField] private UserInput input;
      private MasterBank bank;
      private MasterAnimation animation;
      private MasterMovement movement;
      private MasterRotation rotation;
      private MasterStatusView statusView;
      private MasterInteraction interaction;
      
      public MasterStateMachine stateMachine;
      public InactionMasterState inactionState;
      public WalkMasterState walkState;

      public UserInput Input => input;
      public MasterBank Bank => bank;
      public MasterAnimation Animation => animation;
      public MasterMovement Movement => movement;
      public MasterRotation Rotation => rotation;
      public MasterInteraction Interaction => interaction;

      private void Update()
      {
         stateMachine.CurrentState.LogicUpdate();
      }

      public void Initialize()
      {
         bank = GetComponent<MasterBank>();
         animation = GetComponent<MasterAnimation>();
         movement = GetComponent<MasterMovement>();
         rotation = GetComponent<MasterRotation>();
         statusView = GetComponent<MasterStatusView>();
         interaction = GetComponent<MasterInteraction>();

         if (!input)
            input = FindObjectOfType<UserInput>();

         movement.Initialize();
         statusView.Initialize();
         interaction.Initialize();

         InitializeStateMachine();
      }

      private void InitializeStateMachine()
      {
         stateMachine = GetComponent<MasterStateMachine>();
         inactionState = new InactionMasterState(this, stateMachine);
         walkState = new WalkMasterState(this, stateMachine);

         stateMachine.Initialize(inactionState);
      }
   }
}




