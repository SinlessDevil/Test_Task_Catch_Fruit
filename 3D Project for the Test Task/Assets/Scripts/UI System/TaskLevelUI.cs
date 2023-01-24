using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

namespace UISystem
{
    [RequireComponent(typeof(Level))]
    public class TaskLevelUI : MonoBehaviour
    {     
        [SerializeField] private Image _progressFruitFillBarImage;
        private Level _level;
        private int _maxAmounFruit;
        private int _offsetFillBar = 0;

        private void Awake()
        {
            _level = GetComponent<Level>();
        }

        private void Start()
        {
            _progressFruitFillBarImage.fillAmount = 0f;
            _maxAmounFruit = _level.GetCurrentAmountFruit();
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
            _offsetFillBar = value;
            float val = ((float)_offsetFillBar / (float)_maxAmounFruit);
            _progressFruitFillBarImage.DOFillAmount(val, 0.4f);
        }
    }
}