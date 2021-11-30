using UnityEngine;

namespace Raketa420
{
   public class VfxCreator : MonoBehaviour
   {
      private void CreateFX(GameObject fxPrefab, Vector3 position, Quaternion rotation)
      {
         var fxObject = Instantiate(fxPrefab, position, rotation);
         Destroy(fxObject, 5f);
      }
   }
}

