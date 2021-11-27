using UnityEngine;
using System;

namespace Raketa420
{
   public class ClientAnimation : MonoBehaviour
   {
      [SerializeField] private Animator animator;

      public void SetWalkingAnimation()
      {
         animator.SetBool(AnimationParameterNames.IsWalking, true);
      }

      public void SetIdleAnimation()
      {
         animator.SetBool(AnimationParameterNames.IsWalking, false);
      }
   }
}
