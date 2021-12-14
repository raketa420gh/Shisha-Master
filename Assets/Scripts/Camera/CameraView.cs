using UnityEngine;
using Cinemachine;

namespace Raketa420
{
   public class CameraView : MonoBehaviour
   {
      [SerializeField] private CinemachineVirtualCamera cinemachineVirtualCamera;
      [SerializeField] private Animator cinemachineAnimator;

      private float startSize = 4.5f;
      private float finalSize = 6f;
      private float time = 1f;

      private void OnEnable()
      {
         CameraSizeUpZone.OnMasterEntered += OnHookahsWorkZoneMasterEntered;
         CameraSizeUpZone.OnMasterLeft += OnHookahsWorkZoneMasterLeft;
      }

      private void OnDisable()
      {
         CameraSizeUpZone.OnMasterEntered -= OnHookahsWorkZoneMasterEntered;
         CameraSizeUpZone.OnMasterLeft -= OnHookahsWorkZoneMasterLeft;
      }

      private void Awake()
      {
         InitializeAwake();
      }

      private void InitializeAwake()
      {
         if (!cinemachineVirtualCamera)
         {
            cinemachineVirtualCamera = GetComponentInChildren<CinemachineVirtualCamera>();
         }

         if (!cinemachineAnimator)
         {
            cinemachineAnimator = GetComponent<Animator>();
         }
      }

      private void OnHookahsWorkZoneMasterEntered()
      {
         cinemachineAnimator.SetBool(AnimationParameterNames.IsInside, true);
      }

      private void OnHookahsWorkZoneMasterLeft()
      {
         cinemachineAnimator.SetBool(AnimationParameterNames.IsInside, false);
      }
   }
}

