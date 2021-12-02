using UnityEngine;
using Cinemachine;

namespace Raketa420
{
   public class CameraView : MonoBehaviour
   {
      [SerializeField] private CinemachineVirtualCamera cinemachineVirtualCamera;

      private float startSize = 4.5f;
      private float finalSize = 6f;
      private float time = 1f;

      private void OnEnable()
      {
         HookahsWorkZone.OnMasterEntered += OnHookahsWorkZoneMasterEntered;
         HookahsWorkZone.OnMasterLeft += OnHookahsWorkZoneMasterLeft;
      }

      private void OnDisable()
      {
         HookahsWorkZone.OnMasterEntered -= OnHookahsWorkZoneMasterEntered;
         HookahsWorkZone.OnMasterLeft -= OnHookahsWorkZoneMasterLeft;
      }

      private void Awake()
      {
         InitializeAwake();
      }

      private void Update()
      {
         cinemachineVirtualCamera.m_Lens.OrthographicSize = Mathf.Lerp(cinemachineVirtualCamera.m_Lens.OrthographicSize, finalSize, 1f);
      }

      private void InitializeAwake()
      {
         if (!cinemachineVirtualCamera)
         {
            cinemachineVirtualCamera = GetComponentInChildren<CinemachineVirtualCamera>();
         }
      }

      private void OnHookahsWorkZoneMasterEntered()
      {
         finalSize = 4.5f;
      }

      private void OnHookahsWorkZoneMasterLeft()
      {
         finalSize = 6f;
      }
   }
}

