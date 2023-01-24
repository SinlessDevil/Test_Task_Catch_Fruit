using System;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using UISystem.UIGamePlay;
using SoundSystem;
using FruitSystem;

public class Level : MonoBehaviour
{
    public static event Action OnWinGameEvent;
    public static event Action OnGameOverEvent;

    public event Action<int> OnProgressFruitChangeEvent;
    public event Action<int> OnHealthChangeEvent;

    [Header("------------ Component for Start Game --------------")]
    [SerializeField] private Image _fadeImage;
    [SerializeField] private GameObject _notAnInteractivePanel;
    [SerializeField] private GameObject _buttonStartGame;
    [Space(10)]
    [Header("------------ Setting Current Task --------------")]
    [SerializeField] private TypeFruit _currentTypeFruit;
    [SerializeField] private int _currentAmountFruit;
    [SerializeField] private int _currentAmountHealth;

    private void Start()
    {
        Time.timeScale = 0f;
    }

    private void OnEnable()
    {
        GamePlayButtons.ButtonClickStartGameEvent += SetStartGame;
        TaskGeneration.OnAnnouncementCurrentTaskEvent += SetCurrentTask;
    }

    private void OnDisable()
    {
        GamePlayButtons.ButtonClickStartGameEvent -= SetStartGame;
        TaskGeneration.OnAnnouncementCurrentTaskEvent -= SetCurrentTask;
    }

    #region Set Beginning of Game
    private void SetStartGame()
    {
        Time.timeScale = 1f;

        AudioClips.Instance.PlayClip(DictionaruSounds.STR_AUDIO_CLIP_BUTTON_CLIKC);

        _notAnInteractivePanel.SetActive(false);
        _buttonStartGame.SetActive(false);

        FadeAtStart();
    }

    private void FadeAtStart()
    {
        _fadeImage.DOFade(0f, 1.3f).From(1f);
    }

    private void SetCurrentTask(TypeFruit type, int amountFruit,int amountHealth)
    {
        _currentTypeFruit = type;
        _currentAmountFruit = amountFruit;
        _currentAmountHealth = amountHealth;
    }
    #endregion

    #region Methods Get Current Setting Task 
    public int GetCurrentAmountFruit()
    {
        return _currentAmountFruit;
    }

    public int GetCurrentAmountHealth()
    {
        return _currentAmountHealth;
    }

    public TypeFruit GetTypeFruit()
    {
        return _currentTypeFruit;
    }
    #endregion

    #region Methods Apply New Value
    public void ApplyNewProgressFruit(int value)
    {
        OnProgressFruitChangeEvent?.Invoke(value);
        _currentAmountFruit -= value;
        if (_currentAmountFruit <= 0)
        {
            OnWinGameEvent?.Invoke();
            Debug.Log("WinGame");
        }
    }

    public void ApplyNewHealth(int value)
    {
        OnHealthChangeEvent?.Invoke(value);
        _currentAmountHealth -= value;
        if (_currentAmountHealth <= 0)
        {
            OnGameOverEvent?.Invoke();
            Debug.Log("GameOver");
        }
    }

    #endregion
}