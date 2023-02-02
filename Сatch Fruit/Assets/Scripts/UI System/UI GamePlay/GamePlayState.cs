using UnityEngine;
using UnityEngine.UI;
using PlayerSystem.StateAnimation;
using DG.Tweening;
using SoundSystem;

namespace UISystem.UIGamePlay
{
    public class GamePlayState : MonoBehaviour
    {
        [Header("----------------- Game Panel -----------------")]
        [SerializeField] private GameObject _winGamePanel;
        [SerializeField] private GameObject _gameOverPanel;
        [SerializeField] private GameObject _notInteractivePanel;
        [Space(10)]
        [Header("----------------- Component Win Game -----------------")]
        [SerializeField] private Image _fillBarLvlImage;
        [SerializeField] private ParticleSystem _winFxLvl;
        [Space(10)]
        [Header("----------------- ENVIRONMENT ------------------")]
        [SerializeField] private GameObject[] _objectEnvironment;
        [Space(10)]
        [SerializeField] private CharacterAnimation _animation;


        private void Awake()
        {
            LogError(_winGamePanel);
            LogError(_fillBarLvlImage);
            LogError(_gameOverPanel);
            LogError(_notInteractivePanel);
        }

        private void OnEnable()
        {
            Level.OnWinGameEvent += WinGame;
            Level.OnGameOverEvent += GameOver;
        }

        private void OnDisable()
        {
            Level.OnWinGameEvent -= WinGame;
            Level.OnGameOverEvent -= GameOver;
        }

        private void WinGame()
        {
            _animation.SetBehaviorDancesWinGame();

            ShowPanel(_winGamePanel);
            AudioClips.Instance.PlayClip(DictionaruSounds.STR_AUDIO_CLIP_YOU_WIN_TWO);

            DOTween.Sequence()
                .AppendInterval(1f)
                .Append(_winGamePanel.transform.DOScale(1, 2f))
                .Append(_fillBarLvlImage.DOFillAmount(1f, 2f))
                .AppendCallback(UpNextLvl);
        }

        private void UpNextLvl()
        {
            _winFxLvl.Play();
            AudioClips.Instance.PlayClip(DictionaruSounds.STR_AUDIO_CLIP_YOU_WIN);
        }

        private void GameOver()
        {
            _animation.SetBehaviorDancesGameOver();

            ShowPanel(_gameOverPanel);
            AudioClips.Instance.PlayClip(DictionaruSounds.STR_AUDIO_CLIP_GAME_OVER);

            DOTween.Sequence()
                .AppendInterval(1f)
                .Append(_gameOverPanel.transform.DOScale(1, 2f));
        }

        private void ShowPanel(GameObject panel)
        {
            for (int i = 0; i < _objectEnvironment.Length; i++)
                _objectEnvironment[i].SetActive(false);

            _notInteractivePanel.SetActive(true);
            panel.SetActive(true);
        }

        private void LogError<T>(T component)
        {
            if (component == null)
                throw new System.NullReferenceException($"The {component} Component is not assigned in the inspector!");
        }
    }
}