using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

namespace UISystem
{
    [RequireComponent(typeof(Level))]
    public class HealthUI : MonoBehaviour
    {
        [SerializeField] private Image _healthFillBarImage;
        private Level _level;
        private int _maxAmountHealth;
        private int _offsetFillBar = 0;

        private void Awake()
        {
            _level = GetComponent<Level>();
        }

        private void Start()
        {
            _healthFillBarImage.fillAmount = 1f;
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