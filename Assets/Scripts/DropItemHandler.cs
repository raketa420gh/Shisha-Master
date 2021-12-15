using System;
using UnityEngine;

namespace Raketa420
{
    public class DropItemHandler : MonoBehaviour
    {
        [SerializeField] private Master master;
        [SerializeField] private UserInterface ui;
        
        private void Start()
        {
            if (!master)
                master = FindObjectOfType<Master>();
            
            if(!ui)
                ui = FindObjectOfType<UserInterface>();

            master.Interaction.OnCarryStarted += OnMasterCarryStarted;
            master.Interaction.OnCarryStopped += OnMasterCarryStopped;
        }

        private void OnDisable()
        {
            master.Interaction.OnCarryStarted -= OnMasterCarryStarted;
            master.Interaction.OnCarryStopped -= OnMasterCarryStopped;
        }

        public void DropItem()
        {
            master.Interaction.DropItem();
        }

        private void OnMasterCarryStarted()
        {
            ui.EnableDropItemButton(true);
        }
        
        private void OnMasterCarryStopped()
        {
            ui.EnableDropItemButton(false);
        }
    }
}
