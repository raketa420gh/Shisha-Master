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
      [SerializeField] private Bench bench;

      [Header("Session Settings")]
      [SerializeField] private GameSessionData data;

      public UserInterface UserInterface => userInterface;
      public UserInput Input => input;
      public Spawner Spawner => spawner;
      public GameSessionData Data => data;

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

         if (bench == null)
         {
            bench = FindObjectOfType<Bench>();
         }
         
         InitializeStateMachine();
         
         userInterface.Initialize();
         bench.Initialize();
      }

      private void InitializeStateMachine()
      {
         stateMachine = GetComponent<GameSessionStateMachine>();
         activeState = new ActiveState(this, stateMachine);
         pauseState = new PauseState(this, stateMachine);

         stateMachine.Initialize(activeState);
      }
   }
}
