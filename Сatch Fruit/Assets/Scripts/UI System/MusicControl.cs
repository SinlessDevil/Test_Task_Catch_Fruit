using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using SaveSystem;
using SoundSystem;

namespace UISystem
{
    public class MusicControl : MonoBehaviour
    {
        private const string STR_SOUND_KEY = "sounds";

        public enum TypeScene
        {
            MeinMenu,
            GamePlay
        }
        public TypeScene typeScene;
        [Space(10)]
        [Header("----------------- Image Variabls -----------------")]
        [SerializeField] private Image _iconSound;
        [SerializeField] private Sprite _soundActiveIsTrue;
        [SerializeField] private Sprite _soundActiveIsFalse;
        [Space(10)]
        [SerializeField] private AudioListener _audioListener;

        private bool _isActive = true;

        private void Start(){
            Check—urrentSoundSettings();
        }

        private void OnEnable(){
            switch (typeScene)
            {
                case TypeScene.MeinMenu:
                    UIMeinMenu.MeinMenuButtons.ButtonClickSoundEvent += AudioControl;
                    break;
                case TypeScene.GamePlay:
                    UIGamePlay.GamePlayButtons.ButtonClickSoundPausePanelEvent += AudioControl;
                    break;
            }
        }
        private void OnDisable(){
            switch (typeScene)
            {
                case TypeScene.MeinMenu:
                    UIMeinMenu.MeinMenuButtons.ButtonClickSoundEvent -= AudioControl;
                    break;
                case TypeScene.GamePlay:
                    UIGamePlay.GamePlayButtons.ButtonClickSoundPausePanelEvent -= AudioControl;
                    break;
            }
        }

        private void Check—urrentSoundSettings()
        {
            int currentState = Convert.ToInt32(_isActive);
            currentState = SaveSettings.Instance.LoadInt(STR_SOUND_KEY, currentState);
            _isActive = Convert.ToBoolean(currentState);

            if (_isActive) _iconSound.sprite = _soundActiveIsTrue;
            else _iconSound.sprite = _soundActiveIsFalse; 
            
            AudioListener.pause = !_isActive;
        }

        private void AudioControl()
        {
            StartCoroutine(MuteDelayRoutine());
        }

        private IEnumerator MuteDelayRoutine()
        {
            AudioClips.Instance.PlayClip(DictionaruSounds.STR_AUDIO_CLIP_BUTTON_CLIKC);

            yield return new WaitForSecondsRealtime(0.1f);

            if (_isActive) _iconSound.sprite = _soundActiveIsFalse;
            else _iconSound.sprite = _soundActiveIsTrue;

            _isActive = !_isActive;
            AudioListener.pause = !_isActive;

            SaveSettings.Instance.SaveInt(STR_SOUND_KEY, Convert.ToInt32(_isActive));
        }
    }
}