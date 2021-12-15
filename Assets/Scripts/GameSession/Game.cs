using System;
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

      [Header("Session Settings")]
      [SerializeField] private GameplayData data;

      public UserInterface UI => ui;
      public UserInput Input => input;
      public Spawner Spawner => spawner;
      public GameplayData Data => data;

      private void Start()
      {
         Initialize();
      }

      private void OnEnable()
      {
         MasterInteraction.OnItemLifted += MasterOnItemLifted;
         MasterInteraction.OnItemDropped += MasterOnItemDropped;
      }

      private void OnDisable()
      {
         MasterInteraction.OnItemLifted -= MasterOnItemLifted;
         MasterInteraction.OnItemDropped -= MasterOnItemDropped;
      }

      private void Update()
      {
         stateMachine.CurrentState.LogicUpdate();
      }

      public void DropItem()
      {
         master.Interaction.DropItem();
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

         InitializeStateMachine();
         
         ui.Initialize();
         bench.Initialize();
         master.Initialize();
      }

      private void InitializeStateMachine()
      {
         stateMachine = GetComponent<GameStateMachine>();
         gameplayState = new GameplayState(this, stateMachine);
         pauseState = new PauseState(this, stateMachine);

         stateMachine.Initialize(gameplayState);
      }
      
      private void MasterOnItemLifted()
      {
         ui.EnableInteractionItemButton(true);
      }
        
      private void MasterOnItemDropped()
      {
         ui.EnableInteractionItemButton(false);
      }
   }
}
