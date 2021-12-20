using UnityEngine;

namespace Raketa420
{
    public class ServicePlaceManager : MonoBehaviour
    {
        public void Initialize()
        {
            var allServicePlaces = FindObjectsOfType<ServicePlace>();
            var allServicePlacesAmount = allServicePlaces.Length;
            
            Debug.Log($"All service places amount = {allServicePlacesAmount}");
        }

        public void SetHookahAtServicePlace(ServicePlace servicePlace, Hookah hookah)
        {
            hookah.transform.position = servicePlace.TableTrigger.transform.position;
            hookah.SetKinematic(true);
            hookah.Drop(Vector3.zero);
        }
    }
}
