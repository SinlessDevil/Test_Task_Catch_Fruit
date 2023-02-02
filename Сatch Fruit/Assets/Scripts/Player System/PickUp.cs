using System;
using UnityEngine;
using SoundSystem;
using FruitSystem;

namespace PlayerSystem
{
    public class PickUp : MonoBehaviour, ICollisionVisitor
    {
        public event Action OnPutFruitEvent;

        [Header("-------------- Reference At Level --------------")]
        [SerializeField] private Level _level;
        [Header("-------------- Rigging Settings --------------")]
        [SerializeField] private Transform _mainTargetPickUp;
        [SerializeField] private UnityEngine.Animations.Rigging.Rig _rig;
        [SerializeField] private float _weightSpeed = 3f;
        [Space(10)]
        [Header("-------------- PickUp Point  --------------")]
        [SerializeField] private Transform _rightPalm;
        [SerializeField] private Transform _touchPos;

        private bool _isPickUp = false;
        private bool _isTaskFruit = false;
        public bool IsTaskFruit{ get => _isTaskFruit; private set => _isTaskFruit = value; }

        [HideInInspector] public Fruit currentFruit;

        private void Awake()
        {
            LogError(_mainTargetPickUp);

            LogError(_rightPalm);
            LogError(_touchPos);
        }

        private void FixedUpdate()
        {
            //Move To PickUp Fruit
            if (_isPickUp){
                MoveTo(1);
                if (_rig.weight == 1)
                {
                    _isPickUp = false;
                    currentFruit.gameObject.transform.SetParent(_rightPalm.transform);
                    currentFruit.SetTransfromPosition(_touchPos);
                    AudioClips.Instance.PlayClip(DictionaruSounds.STR_AUDIO_CLIP_BUBBLE);
                    OnPutFruitEvent?.Invoke();
                }
            }else{
                MoveTo(0);
                if (_rig.weight == 0) _isPickUp = false;
            }
        }

        private void MoveTo(int target)
        {
            _rig.weight = Mathf.MoveTowards(_rig.weight, target, _weightSpeed * Time.fixedDeltaTime);
        }

        public void Visitor(Fruit collision)
        {
            for (int i = 0; i < _level.currentTasks.Count; i++)
            {
                if (_level.currentTasks[i].typeFruit == collision.GetTypeFruit()){
                    _level.currentTasks[i].amountFruit -= 1;
                    IsTaskFruit = true;
                    break;
                }else{
                    IsTaskFruit = false;
                }
            }

            //Aniamtion Pick Up Fruit
            SetPickUpAnimation(collision);
        }
        private void SetPickUpAnimation(Fruit collision)
        {
            collision.SetActiveMove(false);
            _mainTargetPickUp.position = collision.GetTransfromPosition().position;
            _isPickUp = true;
            currentFruit = collision;
        }

        private void LogError<T>(T component)
        {
            if (component == null)
                throw new NullReferenceException($"The {component} Component is not assigned in the inspector!");
        }
    }
}