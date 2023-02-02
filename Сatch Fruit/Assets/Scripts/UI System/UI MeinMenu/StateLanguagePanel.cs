using UnityEngine;
using SoundSystem;

namespace UISystem.UIMeinMenu
{
    public class StateLanguagePanel : MonoBehaviour
    {
        private const string ANIM_STATE_LANGUAGE_PANEL = "IsState";

        [SerializeField] private Animator _anim;
        private bool _isActive = false;

        private void Awake()
        {
            if (_anim == null)
                throw new System.NullReferenceException("The Animator Component is not assigned in the inspector!");
        }

        private void OnEnable()
        {
            MeinMenuButtons.ButtonClickShowLanguagePanelEvent += ShowLanguagePanel;
            MeinMenuButtons.ButtonClickExitToLanguagePanelEvent += CloseLanguagePanel;
        }

        private void OnDisable()
        {
            MeinMenuButtons.ButtonClickShowLanguagePanelEvent -= ShowLanguagePanel;
            MeinMenuButtons.ButtonClickExitToLanguagePanelEvent -= CloseLanguagePanel;
        }

        private void ShowLanguagePanel()
        {
            AudioClips.Instance.PlayClip(DictionaruSounds.STR_AUDIO_CLIP_BUTTON_CLIKC);
            AudioClips.Instance.PlayClip(DictionaruSounds.STR_AUDIO_CLIP_SHOWPANEL);
            _isActive = true;
            _anim.SetBool(ANIM_STATE_LANGUAGE_PANEL, _isActive);
        }

        private void CloseLanguagePanel()
        {
            AudioClips.Instance.PlayClip(DictionaruSounds.STR_AUDIO_CLIP_BUTTON_CLIKC);
            AudioClips.Instance.PlayClip(DictionaruSounds.STR_AUDIO_CLIP_SHOWPANEL);
            _isActive = false;
            _anim.SetBool(ANIM_STATE_LANGUAGE_PANEL, _isActive);
        }
    }
}