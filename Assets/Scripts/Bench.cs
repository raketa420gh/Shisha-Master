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

      private Master master;

      private void OnEnable()
      {
         benchUI.Canvas.OnClicked += OnBenchCanvasClicked;
      }

      private void OnDisable()
      {
         benchUI.Canvas.OnClicked -= OnBenchCanvasClicked;
      }

      private void OnTriggerEnter(Collider other)
      {
         if (other.GetComponent<Master>())
         {
            benchUI.SetActiveCanvas(true);
         }
      }
      
      private void OnTriggerExit(Collider other)
      {
         if (other.GetComponent<Master>())
         {
            benchUI.SetActiveCanvas(false);
         }
      }

      public void Initialize()
      {
         benchUI = GetComponent<BenchUserInterface>();
         master = FindObjectOfType<Master>();
         
         benchUI.Initialize();
         
         benchUI.SetActiveCanvas(false);
      }

      private void CraftHookah()
      {
         Craft(hookahPrefab);
      }
      
      private void Craft(GameObject item)
      {
         Instantiate(item, craftDoneTransform.position, Quaternion.identity);
      }

      private void OnBenchCanvasClicked()
      {
         CraftHookah();
      }
   }
}

