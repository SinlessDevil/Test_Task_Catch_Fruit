using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using UISystem.UIGamePlay;
using SoundSystem;
using TaskSystem;

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
    [Header("------------ Current Task --------------")]
    [SerializeField] private int _currentTotalAmountFruits;
    [SerializeField] private int _currentAmountHealth;
    [SerializeField] public List<Task> currentTasks;

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
    private void SetCurrentTask(List<Task> tasks, int amountFruits, int amountHealth)
    {
        currentTasks = tasks;
        _currentTotalAmountFruits = amountFruits;
        _currentAmountHealth = amountHealth;
    }
    #endregion

    #region Methods Get Current Setting Task 
    public int GetCurrentAmountFruit()
    {
        return _currentTotalAmountFruits;
    }

    public int GetCurrentAmountHealth()
    {
        return _currentAmountHealth;
    }
    #endregion

    #region Methods Apply New Value
    public void ApplyNewProgressFruit(int value)
    {
        OnProgressFruitChangeEvent?.Invoke(value);

        _currentTotalAmountFruits -= value;
        if (_currentTotalAmountFruits <= 0)
            OnWinGameEvent?.Invoke();

        CheckingAssignments();
    }

    public void ApplyNewHealth(int value)
    {
        OnHealthChangeEvent?.Invoke(value);

        _currentAmountHealth -= value;
        if (_currentAmountHealth <= 0)
            OnGameOverEvent?.Invoke();
    }

    private void CheckingAssignments()
    {
        for (int i = 0; i < currentTasks.Count; i++)
            if (currentTasks[i].amountFruit == 0) currentTasks.RemoveAt(i);
    }
    #endregion
}