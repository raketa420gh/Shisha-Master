using UnityEngine;
using TMPro;

namespace Raketa420
{
   public class ServicePlaceStatusView : MonoBehaviour
   {
      private TextMeshProUGUI statusTMP;
      [SerializeField] private StatusCanvas statusCanvas;
      [SerializeField] private StatusData freeStatus;
      [SerializeField] private StatusData notFreeStatus;

      public void UdpateView(bool isFree)
      {
         if (isFree)
         {
            SetStatusImage(freeStatus);
         }
         else
         {
            SetStatusImage(notFreeStatus);
         }
      }

      private void SetStatusText(string text)
      {
         statusTMP.text = text;
      }

      private void SetStatusImage(StatusData status)
      {
         statusCanvas.SetImage(status.Sprite);
      }
   }
}