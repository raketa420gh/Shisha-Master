using System;
using UnityEngine;

namespace Raketa420
{
    public class MasterInteraction : MonoBehaviour
    {
        [SerializeField] private Transform hand;
        private bool canCarry = true;
        private PickUpItem currentItemInHand;

        public event Action OnCarryStarted;
        public event Action OnCarryStopped;

        public void Initialize()
        {
            hand = GetComponentInChildren<HandPoint>().transform;
        }

        public void DropItem()
        {
            if (currentItemInHand)
            {
                currentItemInHand.Drop();
                currentItemInHand = null;
                Invoke(nameof(EnableCanCarry), 3f);
            
                OnCarryStopped?.Invoke();
            }
            else
            {
                Debug.LogError("You are no carry item");
            }
        }
        
        private void OnTriggerEnter(Collider other)
        {
            if (!canCarry) 
                return;
            
            var pickUpItem = other.GetComponent<PickUpItem>();

            if (pickUpItem == null) 
                return;
            
            pickUpItem.Carry(transform, hand);
            currentItemInHand = pickUpItem;
            canCarry = false;
            
            OnCarryStarted?.Invoke();
        }

        private void EnableCanCarry()
        {
            canCarry = true;
        }
    }
}