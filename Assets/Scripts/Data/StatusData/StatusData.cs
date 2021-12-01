using UnityEngine;

namespace Raketa420
{
   [CreateAssetMenu(fileName = "CharacterStatus", menuName = "Character/Status", order = 51)]

   public class StatusData : ScriptableObject
   {
      public string Text;
      public Sprite Sprite;
   }
}