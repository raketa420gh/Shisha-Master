using UnityEngine;
using UnityEngine.UI;

namespace Raketa420
{
   public class StatusCanvas : MonoBehaviour
   {
      [SerializeField] private Image iconImage;
      [SerializeField] private Image fillerImage;

      public Image IconImage => iconImage;

      private void Start()
      {
         Initialize();
      }

      public void SetImage(Sprite sprite)
      {
         iconImage.sprite = sprite;
      }

      public void SetFillerValue(float normalized)
      {
         fillerImage.fillAmount = normalized;
      }

      private void Initialize()
      {
         var canvas = this;

         if (canvas != null)
         {
            var statusIcon = canvas.GetComponentInChildren<StatusIcon>();

            if (statusIcon != null)
            {
               var image = statusIcon.GetComponent<Image>();

               if (image != null)
               {
                  iconImage = image;
               }
            }

            var statusFiller = canvas.GetComponentInChildren<StatusFiller>();

            if (statusFiller != null)
            {
               var image = statusFiller.GetComponent<Image>();

               if (image != null)
               {
                  fillerImage = image;
               }
            }
         }
      }
   }
}
