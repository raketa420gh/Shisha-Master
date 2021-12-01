using UnityEngine;

namespace Raketa420
{
   [RequireComponent(typeof(BarBank))]

   public class BarManagment : MonoBehaviour
   {
      [SerializeField] private BarBank bank;

      private void Awake()
      {
         Initialize();
      }

      private void Initialize()
      {
         bank = GetComponent<BarBank>();
      }
   }
}
