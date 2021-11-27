using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace Raketa420
{
   public class UserInterface : MonoBehaviour
   {
      [SerializeField] private GameObject hudPanel;
      [SerializeField] private GameObject masterStatusPanel;
      [SerializeField] private TextMeshProUGUI masterStatusTMP;

      public TextMeshProUGUI MasterStatusTMP => masterStatusTMP;

      public void EnableHUD(bool isActive)
      {
         hudPanel.gameObject.SetActive(isActive);
      }

      public void EnableMasterStatusPanel(bool isActive)
      {
         masterStatusPanel.gameObject.SetActive(isActive);
      }
   }
}

