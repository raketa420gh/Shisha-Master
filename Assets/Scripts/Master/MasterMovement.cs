using UnityEngine;

namespace Raketa420
{
   [RequireComponent(typeof(CharacterController))]
   
   public class MasterMovement : MonoBehaviour
   {
      private CharacterController characterController;
      private float speed = 3f;
      
      public float Speed => speed;

      public void Initialize()
      {
         characterController = GetComponent<CharacterController>();
      }

      public void Move(Vector3 direction)
      {
         characterController.Move(direction * speed * Time.deltaTime);
      }

      public Vector3 GetVelocity()
      {
         return characterController.velocity;
      }
   }
}
