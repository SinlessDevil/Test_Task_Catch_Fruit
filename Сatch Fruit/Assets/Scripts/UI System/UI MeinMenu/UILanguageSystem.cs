using Localization;
using UnityEngine;
using SoundSystem;

namespace UISystem.UIMeinMenu
{
    public class UILanguageSystem : MonoBehaviour
    {
        private void OnEnable()
        {
            MeinMenuButtons.ButtonClickEnglishLanguageEvent += SetEnglish;
            MeinMenuButtons.ButtonClickUkrainianLanguageEvent += SetUkrainian;
        }

        private void OnDisable()
        {
            MeinMenuButtons.ButtonClickEnglishLanguageEvent -= SetEnglish;
            MeinMenuButtons.ButtonClickUkrainianLanguageEvent -= SetUkrainian;
        }

        private void SetEnglish()
        {
            AudioClips.Instance.PlayClip(DictionaruSounds.STR_AUDIO_CLIP_BUTTON_CLIKC);
            Localize.SetCurrentLanguage(SystemLanguage.English);
        }

        private void SetUkrainian()
        {
            AudioClips.Instance.PlayClip(DictionaruSounds.STR_AUDIO_CLIP_BUTTON_CLIKC);
            Localize.SetCurrentLanguage(SystemLanguage.Ukrainian);
        }
    }
}