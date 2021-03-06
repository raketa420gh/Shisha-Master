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
      [SerializeField] private float craftingPeriod = 1f;
      private bool canCraft;

      public static event Action OnCrafted;

      public BenchUserInterface BenchUI => benchUI;

      public void Initialize()
      {
         benchUI = GetComponent<BenchUserInterface>();
         
         benchUI.SetActiveCanvas(false);
         canCraft = true;
      }

      public void CraftHookah()
      {
         Craft(hookahPrefab);
      }
      
      private void Craft(GameObject item)
      {
         if (canCraft)
         {
            Instantiate(item, craftDoneTransform.position, Quaternion.identity);
            canCraft = false;
            Invoke(nameof(SetCanCraftTrue), craftingPeriod);
            
            OnCrafted?.Invoke();
         }
         else
         {
            Debug.Log("You can not craft.");
         }
      }

      private void SetCanCraftTrue()
      {
         canCraft = true;
      }
   }
}

