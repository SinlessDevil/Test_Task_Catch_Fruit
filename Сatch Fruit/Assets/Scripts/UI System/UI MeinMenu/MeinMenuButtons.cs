using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace UISystem.UIMeinMenu
{
    public class MeinMenuButtons : MonoBehaviour
    {
        public static event Action ButtonClickEnglishLanguageEvent;
        public static event Action ButtonClickUkrainianLanguageEvent;
        public static event Action ButtonClickExitToLanguagePanelEvent;

        public static event Action ButtonClickShowLanguagePanelEvent;

        public static event Action ButtonClickPlayGameEvent;
        public static event Action ButtonClickExitEvent;

        public static event Action ButtonClickSoundEvent;

        [Header("----------------------- MeinMenu Buttons -----------------------")]
        [SerializeField] private Button _buttonEnglishLanguage;
        [SerializeField] private Button _buttonUkrainianLanguage;
        [SerializeField] private Button _buttonExitToLanguage;
        [Space(5)]
        [SerializeField] private Button _buttonShowLanguagePanel;
        [Space(5)]
        [SerializeField] private Button _buttonPlayGame;
        [SerializeField] private Button _buttonExit;
        [Space(5)]
        [SerializeField] private Button _buttonSound;

        private void Awake()
        {
            ButtonClickSetting(_buttonEnglishLanguage, OnEnglishLanguageButtonClick);
            ButtonClickSetting(_buttonUkrainianLanguage, OnUkrainianLanguageButtonClick);
            ButtonClickSetting(_buttonExitToLanguage, OnExitToLanguagePanelButtonClick);

            ButtonClickSetting(_buttonShowLanguagePanel, OnChangeLanguageButtonClick);

            ButtonClickSetting(_buttonPlayGame, OnPlayGameButtonClick);
            ButtonClickSetting(_buttonExit, OnExitButtonClick);

            ButtonClickSetting(_buttonSound, OnSoundButtonClick);
        }

        private void ButtonClickSetting(Button button, UnityAction call)
        {
            button.onClick.RemoveAllListeners();
            button.onClick.AddListener(call);
        }

        private void OnEnglishLanguageButtonClick() => ButtonClickEnglishLanguageEvent?.Invoke();
        private void OnUkrainianLanguageButtonClick() => ButtonClickUkrainianLanguageEvent?.Invoke();
        private void OnExitToLanguagePanelButtonClick() => ButtonClickExitToLanguagePanelEvent?.Invoke();
        private void OnChangeLanguageButtonClick() => ButtonClickShowLanguagePanelEvent?.Invoke();
        private void OnPlayGameButtonClick() => ButtonClickPlayGameEvent?.Invoke();
        private void OnExitButtonClick() => ButtonClickExitEvent?.Invoke();
        private void OnSoundButtonClick() => ButtonClickSoundEvent?.Invoke();
    }
}