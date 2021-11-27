using UnityEngine;

namespace Raketa420
{
   public class GameSession : MonoBehaviour
   {
      public GameSessionStateMachine stateMachine;
      public ActiveState activeState;
      public PauseState pauseState;

      [Header("Components")]
      [SerializeField] private UserInterface userInterface;
      [SerializeField] private UserInput input;
      [SerializeField] private Spawner spawner;

      [Header("Session Settings")]
      [SerializeField] private GameSessionData data;

      public UserInterface UserInterface => userInterface;
      public UserInput Input => input;
      public Spawner Spawner => spawner;
      public GameSessionData Data => data;

      private void OnEnable()
      {
         UserInput.OnPressedM += OnPressedM;
         UserInput.OnPressedC += OnPressedC;
      }

      private void OnDisable()
      {
         UserInput.OnPressedM -= OnPressedM;
         UserInput.OnPressedC -= OnPressedC;
      }

      private void Start()
      {
         InitializeComponents();
         InitializeStateMachine();
      }

      private void Update()
      {
         stateMachine.CurrentState.LogicUpdate();
      }

      private void InitializeComponents()
      {
         if (input == null)
         {
            input = FindObjectOfType<UserInput>();
         }

         if (spawner == null)
         {
            spawner = FindObjectOfType<Spawner>();
         }

         if (userInterface == null)
         {
            userInterface = FindObjectOfType<UserInterface>();
         }
      }

      private void InitializeStateMachine()
      {
         stateMachine = GetComponent<GameSessionStateMachine>();
         activeState = new ActiveState(this, stateMachine);
         pauseState = new PauseState(this, stateMachine);

         stateMachine.Initialize(activeState);
      }

      private void OnPressedM()
      {
         spawner.SpawnMaster(data.MasterStartPosition);
      }

      private void OnPressedC()
      {

      }
   }
}
