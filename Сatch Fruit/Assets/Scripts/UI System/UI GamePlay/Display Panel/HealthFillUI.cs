using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

namespace UISystem.DisplayPanel
{
    public class HealthFillUI : MonoBehaviour
    {
        [SerializeField] private Image _healthFillBarImage;
        [SerializeField] private Level _level;
        private int _maxAmountHealth;
        private int _offsetFillBar = 0;

        private void Start()
        {
            StartCoroutine(StartInitializationRoutine());
        }

        private IEnumerator StartInitializationRoutine()
        {
            _healthFillBarImage.fillAmount = 1f;
            yield return new WaitForSeconds(1.5f);
            _maxAmountHealth = _level.GetCurrentAmountHealth();
        }

        private void OnEnable()
        {
            _level.OnHealthChangeEvent += UpdateHealth;
        }

        private void OnDisable()
        {
            _level.OnHealthChangeEvent -= UpdateHealth;
        }

        private void UpdateHealth(int value)
        {
            _offsetFillBar += value;
            float val = 1f - ((float)_offsetFillBar / (float)_maxAmountHealth);

            _healthFillBarImage.DOFillAmount(val, 0.4f);
        }
    }
}