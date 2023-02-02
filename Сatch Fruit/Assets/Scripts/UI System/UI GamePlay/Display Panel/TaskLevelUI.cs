using System;
using System.Text;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using TaskSystem;

namespace UISystem.DisplayPanel
{
    public class TaskLevelUI : MonoBehaviour
    {
        [Header("---------------- Sprite Fruit ----------------")]
        [SerializeField] private Sprite[] _spritesFruit; // Place Sprite in the same position as the names in TypeFruit
        [Space(10)]
        [Header("---------------- Display Component ----------------")]
        [SerializeField] private TMP_Text _textAmountHealthTaskOnFront;
        [Space]
        [SerializeField] private TMP_Text[] _textAmountFruitTaskOnFront;
        [SerializeField] private Image[] _imageFruitTaskOnFront;
        [Space]
        [SerializeField] private TMP_Text _textAmountFruitTaskOnPausePanel;
        [Space(10)]
        [Header("---------------- Reference Component ----------------")]
        [SerializeField] private TaskGeneration _taskGeneration;

        private void Awake()
        {
            LogError(_textAmountFruitTaskOnFront);
            LogError(_imageFruitTaskOnFront);
            LogError(_textAmountHealthTaskOnFront);
            LogError(_textAmountFruitTaskOnPausePanel);

            LogError(_taskGeneration);
        }

        private void OnEnable()
        {
            _taskGeneration.OnDisplayTaskChangeEvent += DisplayTask;
        }

        private void OnDisable()
        {
            _taskGeneration.OnDisplayTaskChangeEvent -= DisplayTask;
        }

        private void DisplayTask(Task[] taskes, int amountHealth)
        {
            var str = new StringBuilder();
            for (int i = 0; i < taskes.Length; i++)
            {
                _imageFruitTaskOnFront[i].sprite = _spritesFruit[((int)taskes[i].typeFruit)];
                _textAmountFruitTaskOnFront[i].text = taskes[i].amountFruit.ToString();

                str.Append("Collect ");
                str.Append(taskes[i].amountFruit.ToString());
                str.Append(" ");
                str.Append(taskes[i].typeFruit.ToString());
                str.Append(".");
                if (i != taskes.Length - 1) str.Append(Environment.NewLine);

            }

            _textAmountFruitTaskOnPausePanel.text = str.ToString();

            _textAmountHealthTaskOnFront.text = " / " + amountHealth.ToString();
        }


        private void LogError<T>(T component)
        {
            if (component == null)
                throw new System.NullReferenceException($"The {component} Component is not assigned in the inspector!");
        }
    }
}