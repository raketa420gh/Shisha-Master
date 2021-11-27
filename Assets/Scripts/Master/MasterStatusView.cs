using UnityEngine;
using TMPro;

namespace Raketa420
{
   public class MasterStatusView : MonoBehaviour
   {
      [SerializeField] private TextMeshProUGUI statusTMP;
      [SerializeField] private StatusCanvas statusCanvas;

      public StatusCanvas StatusCanvas => statusCanvas;

      private void OnEnable()
      {
         MasterBank.OnStatusChanged += OnMasterStatusChanged;
      }

      private void OnDisable()
      {
         MasterBank.OnStatusChanged -= OnMasterStatusChanged;
      }

      private void Start()
      {
         Initialize();
      }

      private void Initialize()
      {
         statusCanvas = GetComponentInChildren<StatusCanvas>();

         var userInterface = FindObjectOfType<UserInterface>();

         if (userInterface != null)
         {
            statusTMP = userInterface.MasterStatusTMP;
         }
         else
         {
            Debug.LogError($"UserInterface не найден");
         }
      }

      private void SetStatusText(string text)
      {
         statusTMP.text = text;
      }

      private void SetStatusImage(Sprite sprite)
      {
         statusCanvas.SetImage(sprite);
      }

      private void SetStatusFillerValue(float normalized)
      {
         statusCanvas.SetFillerValue(normalized);
      }

      private void OnMasterStatusChanged(StatusData status)
      {
         Initialize();
         SetStatusImage(status.Sprite);
         SetStatusText(status.Text);
      }
   }
}

