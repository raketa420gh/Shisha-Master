using UnityEngine;

namespace Raketa420
{
   [CreateAssetMenu(fileName = "SessionSettings", menuName = "Session/SessionSettings", order = 51)]

   public class GameplayData : ScriptableObject
   {
      [Header("Spawn positions")]
      public Vector3 ClientStartPosition;
      
      [Header("Points")]
      public int MaxServicePoints;
   }
}