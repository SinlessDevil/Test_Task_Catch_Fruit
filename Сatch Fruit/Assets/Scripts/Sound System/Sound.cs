using UnityEngine;

namespace SoundSystem
{
    [System.Serializable]
    public class Sound
    {
        public string name;

        public AudioClip clip;

        [Range(0f, 1f)]
        public float volume;

        [Range(.1f, 3f)]
        public float pitch;

        public bool loop;

        public bool playOnAwake;

        [HideInInspector]
        public AudioSource source;
    }
}