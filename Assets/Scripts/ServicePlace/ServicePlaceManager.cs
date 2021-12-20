using UnityEngine;

namespace Raketa420
{
    public class ServicePlaceManager : MonoBehaviour
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

        public void SetHookahAtServicePlace(ServicePlace servicePlace, Hookah hookah)
        {
            hookah.transform.position = servicePlace.TableTrigger.transform.position;
            hookah.SetKinematic(true);
            hookah.Drop(Vector3.zero);
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
