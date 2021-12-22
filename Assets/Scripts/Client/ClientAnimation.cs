using UnityEngine;

namespace Raketa420
{
   public class ClientAnimation : MonoBehaviour
   {
      [SerializeField] private Animator animator;

      public void SetWalkingAnimation()
      {
         animator.SetBool(AnimationParameterNames.IsWalking, true);
         animator.SetBool(AnimationParameterNames.IsSitting, false);
      }

      public void SetIdleAnimation()
      {
         animator.SetBool(AnimationParameterNames.IsWalking, false);
      }

      public void SetSittingAnimation()
      {
         animator.SetBool(AnimationParameterNames.IsWalking, false);
         animator.SetBool(AnimationParameterNames.IsSitting, true);
      }
   }
}
