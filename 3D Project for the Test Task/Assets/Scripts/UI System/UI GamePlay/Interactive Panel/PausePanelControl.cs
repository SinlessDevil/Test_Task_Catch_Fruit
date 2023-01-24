using UnityEngine;
using SoundSystem;

namespace UISystem.UIGamePlay.InteractivePanel
{
    public sealed class PausePanelControl : AbstractPanelControl
    {
        private const string ANIM_STATE_PAUSE_PANEL = "IsState";

        [SerializeField] private GameObject _pausePanel;
        [SerializeField] private GameObject _isNotInteractivePanel;
        [SerializeField] private Animator _anim;
        private bool _isActive = false;

        private void Awake()
        {
            LogError(_pausePanel);
            LogError(_isNotInteractivePanel);
            LogError(_anim);
        }

        private void OnEnable()
        {
            GamePlayButtons.ButtonClickOpenPausePanelEvent += ShowPanel;
            GamePlayButtons.ButtonClickClosePausePanelEvent += ClosePanel;
            GamePlayButtons.ButtonClickExitToMenuPausePanelEvent += ExitToMeinMenu;
            GamePlayButtons.ButtonClickRestartPausePanelEvent += RestartThisScene;
        }

        private void OnDisable()
        {
            GamePlayButtons.ButtonClickOpenPausePanelEvent -= ShowPanel;
            GamePlayButtons.ButtonClickClosePausePanelEvent -= ClosePanel;
            GamePlayButtons.ButtonClickExitToMenuPausePanelEvent -= ExitToMeinMenu;
            GamePlayButtons.ButtonClickRestartPausePanelEvent -= RestartThisScene;
        }

        private void ShowPanel()
        {
            AudioClips.Instance.PlayClip(DictionaruSounds.STR_AUDIO_CLIP_BUTTON_CLIKC);
            AudioClips.Instance.PlayClip(DictionaruSounds.STR_AUDIO_CLIP_SHOWPANEL);

            _isActive = true;
            _anim.SetBool(ANIM_STATE_PAUSE_PANEL, _isActive);
            SetStatePanels(_isActive);

            Time.timeScale = 0f;
        }

        private void ClosePanel()
        {
            AudioClips.Instance.PlayClip(DictionaruSounds.STR_AUDIO_CLIP_BUTTON_CLIKC);
            AudioClips.Instance.PlayClip(DictionaruSounds.STR_AUDIO_CLIP_SHOWPANEL);

            _isActive = false;
            _anim.SetBool(ANIM_STATE_PAUSE_PANEL, _isActive);
            SetStatePanels(_isActive);

            Time.timeScale = 1f;
        }

        private void SetStatePanels(bool isActive)
        {
           // _pausePanel.SetActive(isActive);
            _isNotInteractivePanel.SetActive(isActive);
        }

        private void LogError<T>(T component)
        {
            if (component == null)
                throw new System.NullReferenceException($"The {component} Component is not assigned in the inspector!");
        }
    }
}