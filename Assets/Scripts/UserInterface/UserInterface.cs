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
      [SerializeField] private Image servicePointsFiller;
      [SerializeField] private Button interactionItemButton;
      [SerializeField] private Button craftButton;

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
      
      public void EnableCraftButton(bool isActive)
      {
         craftButton.gameObject.SetActive(isActive);
      }

      public void SetServicePointsFiller(float normalized)
      {
         servicePointsFiller.fillAmount = normalized;
      }
   }
}

