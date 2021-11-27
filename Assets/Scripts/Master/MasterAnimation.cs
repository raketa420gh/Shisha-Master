using UnityEngine;

namespace Raketa420
{
   public class MasterAnimation : MonoBehaviour
   {
      [SerializeField] private Animator animator;

      public void SetWalkAnimation()
      {
         animator.SetBool(AnimationParameterNames.IsWalking, true);
      }

      public void SetIdleAnimation()
      {
         animator.SetBool(AnimationParameterNames.IsWalking, false);
      }
   }
}
