using UnityEngine;
using UnityEngine.EventSystems;

namespace PlayerSystem
{
    public class TouchScreen : MonoBehaviour
    {
        #region TypePlatrom
        public enum TypePlaform
        {
            Android,
            PC
        }
        public TypePlaform typePlatrom;
        #endregion

        [SerializeField] private float _rayLanght;
        [SerializeField] private LayerMask _layermask;
        [SerializeField] private PickUp _pickUp;

        private Ray _ray;
        private RaycastHit _hit;

        private bool _isInteractive = true;
        private Touch _touch;

        private void Awake()
        {
            if (_pickUp == null)
                throw new System.NullReferenceException($"The {_pickUp} Component is not assigned in the inspector!");
        }

        private void Start()
        {
            _isInteractive = true;
        }

        private void OnEnable()
        {
            Put.OnTouchScreenInteractiveEvent += SetTouchScreen;
        }

        private void OnDisable()
        {
            Put.OnTouchScreenInteractiveEvent -= SetTouchScreen;
        }

        private void SetTouchScreen(bool isInteractive)
        {
            _isInteractive = isInteractive;
        }

        private void Update()
        {
            if (_isInteractive)
            {
                switch (typePlatrom)
                {
                    case TypePlaform.Android:
                        AndroidControl();
                        break;
                    case TypePlaform.PC:
                        PcControl();
                        break;
                }
            }
        }

        #region Methods Control
        private void AndroidControl(){
            if (Input.touchCount > 0){
                _touch = Input.GetTouch(0);
                _ray = Camera.main.ScreenPointToRay(_touch.position);

                Debug.DrawRay(_ray.origin, _ray.direction * 20, Color.red);

                if (Physics.Raycast(_ray, out _hit, _rayLanght, _layermask)){
                    if (_hit.collider.TryGetComponent(out FruitSystem.Fruit fruit)){
                        _isInteractive = false;
                        fruit.Accept(_pickUp);
                    }
                }
            }
        }
        private void PcControl(){
            if (Input.GetMouseButtonDown(0) && !EventSystem.current.IsPointerOverGameObject()){
                _ray = Camera.main.ScreenPointToRay(Input.mousePosition);

                Debug.DrawRay(_ray.origin, _ray.direction * 20, Color.red);

                if (Physics.Raycast(_ray, out _hit, _rayLanght, _layermask)){
                    if (_hit.collider.TryGetComponent(out FruitSystem.Fruit fruit)){
                        _isInteractive = false;
                        fruit.Accept(_pickUp);
                    }
                }
            }
        }
        #endregion
    }
}