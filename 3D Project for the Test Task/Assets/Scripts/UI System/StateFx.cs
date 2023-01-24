using UnityEngine;
using SoundSystem;

namespace UISystem
{
    public class StateFx : MonoBehaviour
    {
        [SerializeField] private ParticleSystem _winAnimationFx;
        private void Start()
        {
            if (_winAnimationFx == null)
                throw new System.NullReferenceException("The ParticleSystem Component is not assigned in the inspector!");
        }

        public void ActivatedParticleEffect()
        {
            AudioClips.Instance.PlayClip(DictionaruSounds.STR_AUDIO_CLIP_YOU_WIN);
            _winAnimationFx.Play();
        }

        public void PlaySoundPickUp()
        {
            AudioClips.Instance.PlayClip(DictionaruSounds.STR_AUDIO_CLIP_BUBBLE);
        }
    }
}