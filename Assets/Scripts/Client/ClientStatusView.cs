using System;
using UnityEngine;
using TMPro;

namespace Raketa420
{
   public class ClientStatusView : MonoBehaviour
   {
      [SerializeField] private StatusCanvas statusCanvas;
      [SerializeField] private TextMeshProUGUI statusTMP;
      private ClientData _data;

      private void Awake()
      {
         _data = GetComponent<ClientData>();
      }

      private void OnEnable()
      {
         _data.OnStatusChanged += OnClientStatusChanged;
      }

      private void OnDisable()
      {
         _data.OnStatusChanged -= OnClientStatusChanged;
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

