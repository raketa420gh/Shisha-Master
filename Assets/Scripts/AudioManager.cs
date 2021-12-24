using UnityEngine;

namespace Raketa420
{
    public class AudioManager : MonoBehaviour
    {
        [SerializeField] private SoundObjectData dropItemData;
        [SerializeField] private SoundObjectData liftItemData;
        [SerializeField] private SoundObjectData runSound;
        [SerializeField] private SoundObjectData craftSound;

        public void Initialize()
        {
            
        }

        public void PlayDropItemSound(Vector3 position)
        {
            CreateSoundObjectOneShot(dropItemData, position);
        }

        public void PlayLiftItemSound(Vector3 position)
        {
            CreateSoundObjectOneShot(liftItemData, position);
        }

        public void PlayRunningSound(Vector3 position)
        {
            CreateSoundObjectOneShot(runSound, position);
        }

        public void PlayCraftSound(Vector3 position)
        {
            CreateSoundObjectOneShot(craftSound, position);
        }

        private void CreateSoundObjectOneShot(SoundObjectData soundData, Vector3 position)
        {
            var soundGameObject = new GameObject(soundData.Name);
            soundGameObject.transform.position = position;
            soundGameObject.transform.SetParent(gameObject.transform);
            var audioSource = soundGameObject.AddComponent<AudioSource>();
            audioSource.clip = soundData.Clip;
            
            audioSource.PlayOneShot(audioSource.clip, soundData.Volume);
            Destroy(soundGameObject.gameObject, audioSource.clip.length);
        }
    }
}