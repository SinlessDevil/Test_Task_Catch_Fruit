using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SoundSystem;
using FruitSystem;

namespace PlayerSystem
{
    [RequireComponent(typeof(Animator))]
    public class PickUp : MonoBehaviour, ICollisionVisitor
    {
        private const string STR_DROP_IN_CART = "TrigDropInCart";
        private const string STR_DROP_OUT_CART = "TrigDropOutCart";
        private const string STR_WIN_GAME = "TrigrWinGame";
        private const string STR_GAME_OVER = "TrigGameOver";

        public static event System.Action<bool> OnTouchScreenInteractiveEvent;

        [Header("-------------- Reference At Level --------------")]
        [SerializeField] private Level _level;
        [Space(10)]
        [Header("-------------- Widget Settings --------------")]
        [SerializeField] private WidgetProgressValue _widgetProgressValuePrefab;
        [SerializeField] private Transform _progressValueContainer;
        [Space]
        [Header("Widget Color")]
        [SerializeField] private Color _colorHealth;
        [SerializeField] private Color _colorProgress;
        [Space(10)]
        [Header("-------------- Rigging Settings --------------")]
        [SerializeField] private Transform _mainTargetPickUp;
        [SerializeField] private UnityEngine.Animations.Rigging.Rig _rig;
        [SerializeField] private float _weightSpeed = 3f;
        [Space(10)]
        [Header("-------------- Point  --------------")]
        [SerializeField] private Transform _rightPalm;
        [SerializeField] private Transform _touchPos;
        [SerializeField] private Transform _cart;
        [SerializeField] private Transform _environment;
        [SerializeField] private List<Transform> _seatsInCart;

        private bool _isPickUp = false;
        private bool _isTaskFruit = false;
        private Animator _anim;
        private Fruit _lastFruit;

        private void Awake()
        {
            LogError(_level);

            LogError(_widgetProgressValuePrefab);
            LogError(_progressValueContainer);

            LogError(_mainTargetPickUp);

            LogError(_rightPalm);
            LogError(_touchPos);
            LogError(_cart);
            LogError(_environment);
        }

        private void Start()
        {
            _anim = GetComponent<Animator>();
        }

        private void FixedUpdate()
        {
            //Move To PickUp Fruit
            if (_isPickUp){
                MoveTo(1);
                if (_rig.weight == 1)
                {
                    _isPickUp = false;
                    _lastFruit.gameObject.transform.SetParent(_rightPalm.transform);
                    _lastFruit.SetTransfromPosition(_touchPos);
                    AudioClips.Instance.PlayClip(DictionaruSounds.STR_AUDIO_CLIP_BUBBLE);
                    StartCoroutine(StartAnimRoutine());
                }
            }else{
                MoveTo(0);
                if (_rig.weight == 0) _isPickUp = false;
            }
        }

        private void OnEnable()
        {
            Level.OnWinGameEvent += SetAnimWinGame;
            Level.OnGameOverEvent += SetAnimGameOver;
        }

        private void OnDisable()
        {
            Level.OnWinGameEvent -= SetAnimWinGame;
            Level.OnGameOverEvent -= SetAnimGameOver;
        }

        private void MoveTo(int target)
        {
            _rig.weight = Mathf.MoveTowards(_rig.weight, target, _weightSpeed * Time.fixedDeltaTime);
        }

        public void Visitor(Fruit collision)
        {
            if(_level.GetTypeFruit() == collision.GetTypeFruit()) _isTaskFruit = true;
            else _isTaskFruit = false;

            //Aniamtion Pick Up Fruit
            SetPickUpAnimation(collision);
        }

        #region Methods Animation
        private void SetAnimDropInCart()
        {
            _anim.SetTrigger(STR_DROP_IN_CART);
        }

        private void SetAnimDropOutCart()
        {
            _anim.SetTrigger(STR_DROP_OUT_CART);
        }

        private void SetAnimWinGame()
        {
            _anim.SetTrigger(STR_WIN_GAME);
        }

        private void SetAnimGameOver()
        {
            _anim.SetTrigger(STR_GAME_OVER);
        }

        private IEnumerator StartAnimRoutine()
        {
            yield return new WaitForSeconds(0.5f);
            if (_isTaskFruit) SetAnimDropInCart();
            else SetAnimDropOutCart();
        }
        #endregion

        #region Methods Drop Fruit
        public void DropFruitInCart(){
            AudioClips.Instance.PlayClip(DictionaruSounds.STR_AUDIO_CLIP_BUBBLE);
            _lastFruit.gameObject.transform.SetParent(_cart.transform);
            _lastFruit.SetTransfromPosition(_seatsInCart[0]);
            _seatsInCart.RemoveAt(0);

            _lastFruit = null;

            _level.ApplyNewProgressFruit(1);
            CreateWidgetProgressValue(_colorProgress, 1, "+");

            OnTouchScreenInteractiveEvent?.Invoke(true);
        }
        public void DropAppleOutCart(){
            AudioClips.Instance.PlayClip(DictionaruSounds.STR_AUDIO_CLIP_BUBBLE);
            _lastFruit.gameObject.transform.SetParent(_environment.transform);
            _lastFruit.SetKinimaticRigidBody(false);

            _lastFruit = null;

            _level.ApplyNewHealth(1);
            CreateWidgetProgressValue(_colorHealth, -1, "");

            OnTouchScreenInteractiveEvent?.Invoke(true);
        }
        #endregion

        private void SetPickUpAnimation(Fruit collision)
        {
            collision.SetActiveMove(false);
            _mainTargetPickUp.position = collision.GetTransfromPosition().position;
            _isPickUp = true;
            _lastFruit = collision;
        }
        private void CreateWidgetProgressValue(Color colorWidget, int amountValue, string sign)
        {
            var widget = Instantiate(_widgetProgressValuePrefab, _progressValueContainer);
            var _maxDistance = 0.5f;
            var randomOffset = Random.insideUnitCircle * _maxDistance;
            var position = _progressValueContainer.position + new Vector3(randomOffset.x, randomOffset.y, 0f);
            widget.transform.position = position;

            widget.SetValue(sign + amountValue.ToString());
            widget.SetColor(colorWidget);
        }

        private void LogError<T>(T component)
        {
            if (component == null)
                throw new System.NullReferenceException($"The {component} Component is not assigned in the inspector!");
        }
    }
}