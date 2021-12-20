using UnityEngine;

namespace Raketa420
{
    public class GameplayEventHandler : MonoBehaviour
    {
        private Game game => GetComponentInParent<Game>();
        
        private void OnEnable()
        {
            MasterInteraction.OnItemLifted += MasterOnItemLifted;
            MasterInteraction.OnItemDropped += MasterOnItemDropped;
            MasterInteraction.OnBenchZoneEntered += OnMasterEntered;
            MasterInteraction.OnBenchZoneExited += OnMasterExited;
            TableTrigger.OnHookahTriggered += TableOnHookahTriggered;
        }

        private void OnDisable()
        {
            MasterInteraction.OnItemLifted -= MasterOnItemLifted;
            MasterInteraction.OnItemDropped -= MasterOnItemDropped;
            MasterInteraction.OnBenchZoneEntered -= OnMasterEntered;
            MasterInteraction.OnBenchZoneExited -= OnMasterExited;
        }

        public void DropItem()
        {
            game.Master.Interaction.DropItem();
        }

        public void CraftHookah()
        {
            game.Bench.CraftHookah();
        }   
        
        private void MasterOnItemLifted()
        {
            game.UI.EnableInteractionItemButton(true);
        }
        
        private void MasterOnItemDropped()
        {
            game.UI.EnableInteractionItemButton(false);
        }
      
        private void OnMasterEntered()
        {
            game.Bench.BenchUI.SetActiveCanvas(true);
            game.UI.EnableCraftButton(true);
        }

        private void OnMasterExited()
        {
            game.Bench.BenchUI.SetActiveCanvas(false);
            game.UI.EnableCraftButton(false);
        }

        private void TableOnHookahTriggered(ServicePlace servicePlace, Hookah hookah)
        {
            game.ServicePlaceManager.SetHookahAtServicePlace(servicePlace, hookah);
        }
    }
}