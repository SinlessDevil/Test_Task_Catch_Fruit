using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PlayerSystem.StateAnimation;
using SoundSystem;

namespace PlayerSystem
{
    [RequireComponent(typeof(PickUp),typeof(CharacterAnimation))]
    public class Put : MonoBehaviour
    {
        public static event Action<bool> OnTouchScreenInteractiveEvent;

        [Header("-------------- Reference At Level --------------")]
        [SerializeField] private Level _level;
        [Space(10)]
        [Header("-------------- Widget Settings --------------")]
        [SerializeField] private WidgetProgressValue _widgetProgressValuePrefab;
        [SerializeField] private Transform _spawnPointWidget;
        [SerializeField] private Color _colorHealth;
        [SerializeField] private Color _colorProgress;
        [Space(10)]
        [Header("-------------- Put Point  --------------")]
        [SerializeField] private Transform _cart;
        [SerializeField] private Transform _posPutDown;
        [SerializeField] private List<Transform> _seatsInCart;

        private PickUp _pickUp;
        private CharacterAnimation _animation;

        private void Awake()
        {
            LogError(_level);

            LogError(_widgetProgressValuePrefab);
            LogError(_spawnPointWidget);

            LogError(_cart);
            LogError(_posPutDown);

            _pickUp = GetComponent<PickUp>();
            _animation = GetComponent<CharacterAnimation>();
        }

        private void OnEnable()
        {
            _pickUp.OnPutFruitEvent += StartAnimationPut;
        }

        private void OnDisable()
        {
            _pickUp.OnPutFruitEvent -= StartAnimationPut;
        }


        #region Methods Animation

        private void StartAnimationPut()
        {
            StartCoroutine(StartAnimRoutine());
        }

        private IEnumerator StartAnimRoutine()
        {
            yield return new WaitForSeconds(0.5f);
            if (_pickUp.IsTaskFruit) _animation.SetBehaviorPutUp();
            else _animation.SetBehaviorPutDown();
        }
        #endregion

        #region Methods Drop Fruit
        public void PutUpInCart()
        {
            AudioClips.Instance.PlayClip(DictionaruSounds.STR_AUDIO_CLIP_BUBBLE);
            _pickUp.currentFruit.gameObject.transform.SetParent(_cart.transform);
            _pickUp.currentFruit.SetTransfromPosition(_seatsInCart[0]);
            _seatsInCart.RemoveAt(0);

            _pickUp.currentFruit.enabled = false;
            _pickUp.currentFruit = null;

            _level.ApplyNewProgressFruit(1);
            CreateWidgetProgressValue(_colorProgress, 1, "+");

            OnTouchScreenInteractiveEvent?.Invoke(true);
        }
        public void PutDownOutCart()
        {
            AudioClips.Instance.PlayClip(DictionaruSounds.STR_AUDIO_CLIP_BUBBLE);
            _pickUp.currentFruit.gameObject.transform.SetParent(_posPutDown.transform);
            _pickUp.currentFruit.SetKinimaticRigidBody(false);

            _pickUp.currentFruit.enabled = false;
            _pickUp.currentFruit = null;

            _level.ApplyNewHealth(1);
            CreateWidgetProgressValue(_colorHealth, -1, "");

            OnTouchScreenInteractiveEvent?.Invoke(true);
        }
        #endregion

        private void CreateWidgetProgressValue(Color colorWidget, int amountValue, string sign)
        {
            var widget = Instantiate(_widgetProgressValuePrefab, _spawnPointWidget);
            var _maxDistance = 0.5f;
            var randomOffset = UnityEngine.Random.insideUnitCircle * _maxDistance;
            var position = _spawnPointWidget.position + new Vector3(randomOffset.x, randomOffset.y, 0f);
            widget.transform.position = position;

            widget.SetValue(sign + amountValue.ToString());
            widget.SetColor(colorWidget);
        }

        private void LogError<T>(T component)
        {
            if (component == null)
                throw new NullReferenceException($"The {component} Component is not assigned in the inspector!");
        }
    }
}