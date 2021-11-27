using UnityEngine;
using TMPro;

namespace Raketa420
{
   public class ClientStatusView : MonoBehaviour
   {
      private TextMeshProUGUI statusTMP;
      [SerializeField] private StatusCanvas statusCanvas;
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

      private void Start()
      {
         Initialize();
      }

      private void Initialize()
      {
         statusCanvas = GetComponentInChildren<StatusCanvas>();
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
      }
   }
}

