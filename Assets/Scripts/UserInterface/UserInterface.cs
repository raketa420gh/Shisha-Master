using System;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace Raketa420
{
   public class UserInterface : MonoBehaviour
   {
      [SerializeField] private UIPanel hudPanel;
      [SerializeField] private UIPanel masterStatusPanel;
      [SerializeField] private TextMeshProUGUI masterStatusTMP;
      [SerializeField] private Image happinessPointsFiller;
      [SerializeField] private Button interactionItemButton;

      public TextMeshProUGUI MasterStatusTMP => masterStatusTMP;

      public void Initialize()
      {
      }

      public void EnableHUD(bool isActive)
      {
         hudPanel.SetActive(isActive);
      }

      public void EnableMasterStatusPanel(bool isActive)
      {
         masterStatusPanel.SetActive(isActive);
      }

      public void EnableInteractionItemButton(bool isActive)
      {
         interactionItemButton.gameObject.SetActive(isActive);
      }

      private void OnHappinessPointsChanged(float normalized)
      {
         happinessPointsFiller.fillAmount = normalized;
      }
   }
}

