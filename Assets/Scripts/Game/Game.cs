using UnityEngine;

namespace Raketa420
{
   public class Game : MonoBehaviour
   {
      public GameStateMachine stateMachine;
      public GameplayState gameplayState;
      public PauseState pauseState;
      
      [Header("Components")]
      [SerializeField] private UserInterface ui;
      [SerializeField] private UserInput input;
      [SerializeField] private Spawner spawner;
      [SerializeField] private Bench bench;
      [SerializeField] private Master master;
      [SerializeField] private ServicePlacesManager servicePlacesManager;
      [SerializeField] private AudioManager audioManager;
      [SerializeField] private PointsManager pointsManager;

      [Header("Session Settings")]
      [SerializeField] private GameplayData data;

      public UserInterface UI => ui;
      public UserInput Input => input;
      public Spawner Spawner => spawner;
      public GameplayData Data => data;
      public Master Master => master;
      public Bench Bench => bench;
      public ServicePlacesManager ServicePlacesManager => servicePlacesManager;
      public AudioManager AudioManager => audioManager;
      public PointsManager PointsManager => pointsManager;

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
         if (!input)
            input = FindObjectOfType<UserInput>();
         if (!spawner)
            spawner = FindObjectOfType<Spawner>();
         if (!ui)
            ui = FindObjectOfType<UserInterface>();
         if (!bench)
            bench = FindObjectOfType<Bench>();
         if (!master)
            master = FindObjectOfType<Master>();
         if (!servicePlacesManager)
            servicePlacesManager = FindObjectOfType<ServicePlacesManager>();
         if (!pointsManager)
            pointsManager = FindObjectOfType<PointsManager>();
         if (!audioManager)
            audioManager = FindObjectOfType<AudioManager>();

         InitializeStateMachine();

         ui.Initialize();
         bench.Initialize();
         master.Initialize();
         servicePlacesManager.Initialize();
         pointsManager.Initialize();
         audioManager.Initialize();
      }

      private void InitializeStateMachine()
      {
         stateMachine = GetComponent<GameStateMachine>();
         gameplayState = new GameplayState(this, stateMachine);
         pauseState = new PauseState(this, stateMachine);

         stateMachine.Initialize(gameplayState);
      }
   }
}
