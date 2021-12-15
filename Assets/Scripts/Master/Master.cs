using UnityEngine;
using Pathfinding;

namespace Raketa420
{
   [RequireComponent(typeof(MasterBank))]
   [RequireComponent(typeof(MasterAnimation))]
   [RequireComponent(typeof(MasterMovement))]
   [RequireComponent(typeof(Seeker))]
   [RequireComponent(typeof(MasterStatusView))]
   [RequireComponent(typeof(MasterInteraction))]
   [RequireComponent(typeof(MasterStateMachine))]

   public class Master : MonoBehaviour
   {
      [SerializeField] private UserInput input;
      
      private MasterBank bank;
      private MasterAnimation animation;
      private MasterMovement movement;
      private MasterStatusView statusView;
      private MasterInteraction interaction;
      
      public MasterStateMachine stateMachine;
      public InactionMasterState inactionState;
      public WalkMasterState walkState;

      public MasterBank Bank => bank;
      public MasterAnimation Animation => animation;
      public MasterMovement Movement => movement;
      public MasterStatusView StatusView => statusView;
      public MasterInteraction Interaction => interaction;
      
      private void OnEnable()
      {
         input.OnClicked += UserInputOnClicked;
      }

      private void OnDisable()
      {
         input.OnClicked += UserInputOnClicked;
      }

      private void Start()
      {
         Initialize();
      }

      private void Update()
      {
         stateMachine.CurrentState.LogicUpdate();
      }

      private void Initialize()
      {
         bank = GetComponent<MasterBank>();
         animation = GetComponent<MasterAnimation>();
         movement = GetComponent<MasterMovement>();
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
      
      private void UserInputOnClicked(Vector3 point)
      {
         movement.MoveTo(point);
         stateMachine.ChangeState(walkState);
      }
   }
}




