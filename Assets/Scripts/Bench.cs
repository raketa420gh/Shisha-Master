using System;
using UnityEngine;

namespace Raketa420
{
   [RequireComponent(typeof(BenchUserInterface))]
   
   public class Bench : MonoBehaviour
   {
      [SerializeField] private BenchUserInterface benchUI;
      [SerializeField] private Transform craftDoneTransform;
      [SerializeField] private GameObject hookahPrefab;

      public BenchUserInterface BenchUI => benchUI;

      public void Initialize()
      {
         benchUI = GetComponent<BenchUserInterface>();
         
         benchUI.SetActiveCanvas(false);
      }

      public void CraftHookah()
      {
         Craft(hookahPrefab);
      }
      
      private void Craft(GameObject item)
      {
         Instantiate(item, craftDoneTransform.position, Quaternion.identity);
      }
   }
}

