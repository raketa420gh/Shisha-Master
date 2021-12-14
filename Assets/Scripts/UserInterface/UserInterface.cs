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

      public TextMeshProUGUI MasterStatusTMP => masterStatusTMP;
      
      public void EnableHUD(bool isActive)
      {
         hudPanel.SetActive(isActive);
      }

      public void EnableMasterStatusPanel(bool isActive)
      {
         masterStatusPanel.SetActive(isActive);
      }

      private void OnHappinessPointsChanged(float normalized)
      {
         happinessPointsFiller.fillAmount = normalized;
      }
   }
}

