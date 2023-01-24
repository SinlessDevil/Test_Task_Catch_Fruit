using System;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using FruitSystem;
public class TaskGeneration : MonoBehaviour
{
    public static event Action<TypeFruit,int, int> OnAnnouncementCurrentTaskEvent;

    [Header("---------------- All Fruits ----------------")]
    [SerializeField] private Sprite[] _fruits; // Place Sprite in the same position as the names in TypeFruit
    [Space(10)]
    [Header("---------------- Generated Task Settings ----------------")]
    [SerializeField] private TypeFruit _typeFruit;
    [SerializeField] private int _amountFruits;
    [SerializeField] private int _amountHealth;
    [Space(10)]
    [Header("---------------- Display Component ----------------")]
    [SerializeField] private TMP_Text _textTaskOnPausePanel;
    [SerializeField] private TMP_Text _textAmountFruitOnFrontPanel;
    [SerializeField] private TMP_Text _textAmountHealthOnFrontPanel;
    [SerializeField] private Image _imageOnFillBar;

    private void Awake()
    {
        LogError(_textTaskOnPausePanel);
        LogError(_textAmountFruitOnFrontPanel);
        LogError(_textAmountHealthOnFrontPanel);
        LogError(_imageOnFillBar);
    }

    private void Start()
    {
        RandomTaskGeneration();

        DisplayTask();

        OnAnnouncementCurrentTaskEvent?.Invoke(_typeFruit, _amountFruits, _amountHealth);
    }

    private void RandomTaskGeneration()
    {
        _typeFruit = (TypeFruit)UnityEngine.Random.Range(0, 4);

        _amountFruits = UnityEngine.Random.Range(1, 6);

        _amountHealth = UnityEngine.Random.Range(1, 4);
    }

    private void DisplayTask()
    {
        _textTaskOnPausePanel.text = "Collect " + _amountFruits.ToString()
            + " " + _typeFruit.ToString() + ".";

        _textAmountFruitOnFrontPanel.text = _amountFruits.ToString() + " / ";

        _textAmountHealthOnFrontPanel.text = " / " + _amountHealth.ToString();

        _imageOnFillBar.sprite = _fruits[((int)_typeFruit)];

    }

    private void LogError<T>(T component)
    {
        if (component == null)
            throw new System.NullReferenceException($"The {component} Component is not assigned in the inspector!");
    }
}