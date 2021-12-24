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
            Client.OnTableTaked += OnClientTableToke;
            ClientData.OnTableReleased += OnTableReleased;
            ClientReaction.OnPositiveReacted += OnClientPositiveReacted;
            ClientReaction.OnNegativeReacted += OnClientNegativeReacted;
            PointsManager.OnServicePointsChanged += OnServicePointsChanged;
        }

        private void OnDisable()
        {
            MasterInteraction.OnItemLifted -= MasterOnItemLifted;
            MasterInteraction.OnItemDropped -= MasterOnItemDropped;
            MasterInteraction.OnBenchZoneEntered -= OnMasterEntered;
            MasterInteraction.OnBenchZoneExited -= OnMasterExited;
            Client.OnTableTaked -= OnClientTableToke;
            ClientData.OnTableReleased -= OnTableReleased;
            ClientReaction.OnPositiveReacted -= OnClientPositiveReacted;
            ClientReaction.OnNegativeReacted -= OnClientNegativeReacted;
            PointsManager.OnServicePointsChanged -= OnServicePointsChanged;
        }

        public void DropItem()
        {
            game.Master.Interaction.DropItem();
        }

        public void CraftHookah()
        {
            game.Bench.CraftHookah();
            game.AudioManager.PlayCraftSound(game.Bench.transform.position);
        }   
        
        private void MasterOnItemLifted()
        {
            game.UI.EnableInteractionItemButton(true);
            game.AudioManager.PlayLiftItemSound(game.Master.Interaction.HandTransform.position);
        }
        
        private void MasterOnItemDropped()
        {
            game.UI.EnableInteractionItemButton(false);
            game.AudioManager.PlayDropItemSound(game.Master.Interaction.HandTransform.position);
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

        private void TableOnHookahTriggered(ServicePlace servicePlace, Hookah hookah, Vector3 triggerPoint)
        {
            game.ServicePlacesManager.SetHookahAtServicePlace(servicePlace, hookah, triggerPoint);
        }
        
        private void OnClientTableToke(Client client, ServicePlace servicePlace)
        {
            game.ServicePlacesManager.SetServicePlaceNotFree(client, servicePlace);
        }

        private void OnTableReleased(ServicePlace servicePlace)
        {
            game.ServicePlacesManager.SetServicePlaceFree(servicePlace);
        }

        private void OnClientPositiveReacted(int pointsToIncrease)
        {
            game.PointsManager.IncreaseServicePoints(pointsToIncrease);
        }

        private void OnClientNegativeReacted(int pointsToDecrease)
        {
            game.PointsManager.DecreaseServicePoints(pointsToDecrease);
        }

        private void OnServicePointsChanged(float normalized)
        {
            game.UI.SetServicePointsFiller(normalized);
        }
    }
}