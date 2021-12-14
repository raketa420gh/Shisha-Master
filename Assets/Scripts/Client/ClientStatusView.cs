using System;
using UnityEngine;
using TMPro;

namespace Raketa420
{
   public class ClientStatusView : MonoBehaviour
   {
      [SerializeField] private StatusCanvas statusCanvas;
      [SerializeField] private TextMeshProUGUI statusTMP;
      private ClientBank bank;

      private void Awake()
      {
         bank = GetComponent<ClientBank>();
      }

      private void OnEnable()
      {
         bank.OnStatusChanged += OnClientStatusChanged;
      }

      private void OnDisable()
      {
         bank.OnStatusChanged -= OnClientStatusChanged;
      }

      public void Initialize()
      {
         statusCanvas = GetComponentInChildren<StatusCanvas>();
         statusTMP = statusCanvas.GetComponentInChildren<TextMeshProUGUI>();
      }

      public void SetStatusFillerValue(float normalized)
      {
         statusCanvas.SetFillerValue(normalized);
      }

      private void SetStatusText(string text)
      {
         statusTMP.text = text;
      }

      private void OnClientStatusChanged(StatusData status)
      {
         statusCanvas.SetImage(status.Sprite);
         SetStatusText(status.Text);
      }
   }
}

