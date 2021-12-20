using System;
using UnityEngine;

namespace Raketa420
{
    public class TableTrigger : MonoBehaviour
    {
        [SerializeField] private ServicePlace servicePlace;
        
        public static event Action<ServicePlace, Hookah> OnHookahTriggered;
        
        private void OnTriggerEnter(Collider other)
        {
            var hookah = other.GetComponent<Hookah>();

            if (!hookah)
                return;

            OnHookahTriggered?.Invoke(servicePlace, hookah);
        }
    }
}
