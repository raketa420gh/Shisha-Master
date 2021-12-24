using UnityEngine;

namespace Raketa420
{
    [CreateAssetMenu(fileName = "SoundFX", menuName = "FX/Sound", order = 51)]
    
    public class SoundObjectData : ScriptableObject
    {
        public string Name = "Sound";
        public AudioClip Clip;
        [Range(0f, 1f)] public float Volume = 0.5f;
    }
}