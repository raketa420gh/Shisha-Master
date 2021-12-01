using UnityEngine;

namespace Raketa420
{
   [CreateAssetMenu(fileName = "SessionSettings", menuName = "Session/SessionSettings", order = 51)]

   public class GameSessionData : ScriptableObject
   {
      public Vector3 MasterStartPosition;
      public Vector3 ClientStartPosition;
      public int MaxHappinessPointsAmount;
   }
}