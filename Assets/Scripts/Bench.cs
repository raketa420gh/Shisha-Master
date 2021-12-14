using UnityEngine;

namespace Raketa420
{
   public class Bench : MonoBehaviour
   {
      [SerializeField] private Transform craftDoneTransform;
      [SerializeField] private GameObject hookahPrefab;

      private Master master;

      public void Initialize()
      {
         master = FindObjectOfType<Master>();
      }

      private void CraftHookah()
      {
         Craft(hookahPrefab);
      }
      
      private void Craft(GameObject item)
      {
         Instantiate(item, craftDoneTransform.position, Quaternion.identity);
      }

      private void OnTriggerEnter(Collider other)
      {
         if (other.GetComponent<Master>())
         {
            CraftHookah();
         }
      }
   }
}

