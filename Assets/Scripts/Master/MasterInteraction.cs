using System;
using UnityEngine;

namespace Raketa420
{
    public class MasterInteraction : MonoBehaviour
    {
        [SerializeField] private Transform hand;
        private bool canLift = true;
        private LiftedItem currentItemInHand;

        public static event Action OnItemLifted;
        public static event Action OnItemDropped;
        public static event Action OnBenchZoneEntered;
        public static event Action OnBenchZoneExited;

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
                Invoke(nameof(EnableCanLift), 3f);
            
                OnItemDropped?.Invoke();
            }
            else
            {
                Debug.LogError("You can not lift an item");
            }
        }
        
        private void OnTriggerEnter(Collider other)
        {
            if (other.GetComponent<Bench>())
            {
                OnBenchZoneEntered?.Invoke();
            }
            
            if (!canLift) 
                return;
            
            var pickUpItem = other.GetComponent<LiftedItem>();

            if (pickUpItem == null) 
                return;
            
            pickUpItem.Lift(transform, hand);
            currentItemInHand = pickUpItem;
            canLift = false;
            
            OnItemLifted?.Invoke();
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.GetComponent<Bench>())
            {
                OnBenchZoneExited?.Invoke();
            }
        }

        private void EnableCanLift()
        {
            canLift = true;
        }
    }
}