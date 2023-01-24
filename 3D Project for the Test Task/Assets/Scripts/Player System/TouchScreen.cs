using UnityEngine;
using UnityEngine.EventSystems;

namespace PlayerSystem
{
    public class TouchScreen : MonoBehaviour
    {
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
            PickUp.OnTouchScreenInteractiveEvent += SetTouchScreen;
        }

        private void OnDisable()
        {
            PickUp.OnTouchScreenInteractiveEvent -= SetTouchScreen;
        }

        private void SetTouchScreen(bool isInteractive)
        {
            _isInteractive = isInteractive;
        }

        private void Update()
        {
            if (_isInteractive)
            {
                //Input.GetMouseButtonDown(0) && !EventSystem.current.IsPointerOverGameObject()
                if (Input.touchCount > 0)
                {
                    _touch = Input.GetTouch(0);
                    _ray = Camera.main.ScreenPointToRay(_touch.position);
                    //_ray = Camera.main.ScreenPointToRay(Input.mousePosition);

                    Debug.DrawRay(_ray.origin, _ray.direction * 20, Color.red);

                    if (Physics.Raycast(_ray, out _hit, _rayLanght, _layermask))
                    {
                        if (_hit.collider.TryGetComponent(out FruitSystem.Fruit fruit))
                        {
                            _isInteractive = false;
                            fruit.Accept(_pickUp);
                        }
                    }
                }
            }
        }
    }
}