using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

namespace UISystem.DisplayPanel
{
    public class TaskFilllUI : MonoBehaviour
    {     
        [SerializeField] private Image _progressFruitFillBarImage;
        [SerializeField] private Level _level;

        private int _maxAmounFruit;
        private int _offsetFillBar = 0;

        private void Start()
        {
            StartCoroutine(StartInitializationRoutine());
        }

        private IEnumerator StartInitializationRoutine()
        {
            _progressFruitFillBarImage.fillAmount = 0f;
            yield return new WaitForSeconds(1f);
            _maxAmounFruit = _level.GetCurrentAmountFruit();
            Debug.Log(_maxAmounFruit);
        }

        private void OnEnable()
        {
            _level.OnProgressFruitChangeEvent += UpdateProgressFruit;
        }

        private void OnDisable()
        {
            _level.OnProgressFruitChangeEvent -= UpdateProgressFruit;
        }

        private void UpdateProgressFruit(int value)
        {
            _offsetFillBar += value;
            float val =  ((float)_offsetFillBar / (float)_maxAmounFruit);
            Debug.Log(val + " = " + (float)_offsetFillBar + "/" + (float)_maxAmounFruit);
            _progressFruitFillBarImage.DOFillAmount(val, 0.4f);
        }
    }
}