using UnityEngine;
using Pathfinding;

namespace Raketa420
{
   [RequireComponent(typeof(MasterBank))]
   [RequireComponent(typeof(MasterAnimation))]
   [RequireComponent(typeof(MasterMovement))]
   [RequireComponent(typeof(Seeker))]
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


      private void OnEnable()
      {
         UserInput.OnClicked += UserInputOnClicked;
      }

      private void OnDisable()
      {
         UserInput.OnClicked += UserInputOnClicked;
      }

      private void UserInputOnClicked(Vector3 point)
      {
         movement.MoveTo(point);
         stateMachine.ChangeState(walkState);
      }

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

      private void InitializeSelfComponents()
      {
         bank = GetComponent<MasterBank>();
         animation = GetComponent<MasterAnimation>();
         movement = GetComponent<MasterMovement>();
         statusView = GetComponent<MasterStatusView>();
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




