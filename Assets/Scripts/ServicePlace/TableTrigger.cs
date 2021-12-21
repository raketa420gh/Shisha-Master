using System;
using UnityEngine;

namespace Raketa420
{
    public class TableTrigger : MonoBehaviour
    {
        [SerializeField] private ServicePlace servicePlace;
        private Vector3 triggerPoint;
        
        public static event Action<ServicePlace, Hookah, Vector3> OnHookahTriggered;
        
        private void OnTriggerEnter(Collider other)
        {
            var hookah = other.GetComponent<Hookah>();

            if (!hookah)
                return;

            triggerPoint = other.ClosestPoint(hookah.transform.position);

            OnHookahTriggered?.Invoke(servicePlace, hookah, triggerPoint);
        }
    }
}
