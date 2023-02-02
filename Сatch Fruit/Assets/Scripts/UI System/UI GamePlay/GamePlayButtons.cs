using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace UISystem.UIGamePlay
{
    public class GamePlayButtons : MonoBehaviour
    {
        public static event Action ButtonClickOpenPausePanelEvent;
        public static event Action ButtonClickClosePausePanelEvent;
        public static event Action ButtonClickExitToMenuPausePanelEvent;
        public static event Action ButtonClickSoundPausePanelEvent;
        public static event Action ButtonClickRestartPausePanelEvent;

        public static event Action ButtonClickStartGameEvent;

        public static event Action ButtonClickExitToMenuWinPanelEvent;
        public static event Action ButtonClickNextLevelWinPanelEvent;

        public static event Action ButtonClickExitTiMenuGameOverPanelEvent;
        public static event Action ButtonClickRestartGameOverPanelEvent;

        [Header("----------------------- Pause Panel Buttons -----------------------")]
        [SerializeField] private Button _buttonOpenPausePanel;
        [SerializeField] private Button _buttonClosePausePanel;
        [SerializeField] private Button _buttonExitToMenuPausePanel;
        [SerializeField] private Button _buttonSoundPausePanel;
        [SerializeField] private Button _buttonRestartPausePanel;
        [Space(5)]
        [Header("----------------------- Front Panel Buttons -----------------------")]
        [SerializeField] private Button _buttonStartGame;
        [Space(5)]
        [Header("----------------------- Win Panel Buttons -----------------------")]
        [SerializeField] private Button _buttonExitToMenuWinPanel;
        [SerializeField] private Button _buttonNextLevelWinPanel;
        [Space(5)]
        [Header("----------------------- GameOver Panel Buttons -----------------------")]
        [SerializeField] private Button _buttonExitTiMenuGameOverPanel;
        [SerializeField] private Button _buttonRestartGameOverPanel;

        private void Awake()
        {
            ButtonClickSetting(_buttonOpenPausePanel, OnOpenPausePanelButtonClick);
            ButtonClickSetting(_buttonClosePausePanel, OnClosePausePanelButtonClick);
            ButtonClickSetting(_buttonExitToMenuPausePanel, OnExitToMenuPausePanelButtonClick);
            ButtonClickSetting(_buttonSoundPausePanel, OnSoundPausePanelButtonClick);
            ButtonClickSetting(_buttonRestartPausePanel, OnRestartPausePanelButtonClick);

            ButtonClickSetting(_buttonStartGame, OStartGameButtonClick);

            ButtonClickSetting(_buttonExitToMenuWinPanel, OnExitToMenuWinPanelButtonClick);
            ButtonClickSetting(_buttonNextLevelWinPanel, OnNextLevelWinPanelButtonClick);

            ButtonClickSetting(_buttonExitTiMenuGameOverPanel, OnExitTiMenuGameOverPanelButtonClick);
            ButtonClickSetting(_buttonRestartGameOverPanel, OnRestartGameOverPanelButtonClick);
        }

        private void ButtonClickSetting(Button button, UnityAction call)
        {
            button.onClick.RemoveAllListeners();
            button.onClick.AddListener(call);
        }

        private void OnOpenPausePanelButtonClick() => ButtonClickOpenPausePanelEvent?.Invoke();
        private void OnClosePausePanelButtonClick() => ButtonClickClosePausePanelEvent?.Invoke();
        private void OnExitToMenuPausePanelButtonClick() => ButtonClickExitToMenuPausePanelEvent?.Invoke();
        private void OnSoundPausePanelButtonClick() => ButtonClickSoundPausePanelEvent?.Invoke();
        private void OnRestartPausePanelButtonClick() => ButtonClickRestartPausePanelEvent?.Invoke();

        private void OStartGameButtonClick() => ButtonClickStartGameEvent?.Invoke();

        private void OnExitToMenuWinPanelButtonClick() => ButtonClickExitToMenuWinPanelEvent?.Invoke();
        private void OnNextLevelWinPanelButtonClick() => ButtonClickNextLevelWinPanelEvent?.Invoke();

        private void OnExitTiMenuGameOverPanelButtonClick() => ButtonClickExitTiMenuGameOverPanelEvent?.Invoke();
        private void OnRestartGameOverPanelButtonClick() => ButtonClickRestartGameOverPanelEvent?.Invoke();
    }
}