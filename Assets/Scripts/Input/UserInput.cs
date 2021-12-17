using UnityEngine;

namespace Raketa420
{
   public class UserInput : MonoBehaviour
   {
      [SerializeField] private Joystick joystick;
      private bool isEnabled;

      public Joystick Joystick => joystick;
      
      private void Update()
      {
         if (!isEnabled)
            return;
      }

      public void Enable(bool isActive)
      {
         isEnabled = isActive;
      }

      public bool IsJoystickDragged()
      {
         return joystick.Horizontal != 0f || joystick.Vertical != 0f;
      }
   }
}

