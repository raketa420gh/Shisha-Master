using UnityEngine;

namespace Raketa420
{
    public class ServicePlacesManager : MonoBehaviour
    {
        private ServicePlace[] allServicePlaces;
        
        public void Initialize()
        {
            allServicePlaces = FindObjectsOfType<ServicePlace>();

            foreach (var servicePlaces in allServicePlaces)
            {
                servicePlaces.Initialize();
            }
            
            var allServicePlacesAmount = allServicePlaces.Length;
            
            Debug.Log($"All service places amount = {allServicePlacesAmount}");
        }

        public void SetHookahAtServicePlace(ServicePlace servicePlace, Hookah hookah, Vector3 triggerPoint)
        {
            hookah.transform.position = triggerPoint;
            hookah.Drop(Vector3.zero);
            hookah.SetKinematic(true);
            servicePlace.SetHaveHookah(true);
        }

        public void SetServicePlaceFree(ServicePlace servicePlace)
        {
            servicePlace.SetFree(true);
        }

        public void SetServicePlaceNotFree(Client client, ServicePlace servicePlace)
        {
            servicePlace.SetFree(false);
        }
    }
}
