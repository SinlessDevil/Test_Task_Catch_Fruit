using UnityEngine;

namespace FruitSystem
{
    [RequireComponent(typeof(Rigidbody))]
    public abstract class Fruit : MonoBehaviour
    {
        [SerializeField] private float _speed;

        private Rigidbody _rb;
        protected TypeFruit _currentTypeFruit;
        private bool _isActive = true;

        protected virtual void Start()
        {
            _rb = GetComponent<Rigidbody>();
        }

        private void FixedUpdate()
        {
            if(_isActive)
                Move();
        }

        public abstract void Accept(ICollisionVisitor collison);

        #region Methods Get
        public TypeFruit GetTypeFruit()
        {
            return _currentTypeFruit;
        }
        public Transform GetTransfromPosition()
        {
            return gameObject.transform;
        }
        public void SetTransfromPosition(Transform pos)
        {
            transform.position = pos.position;
        }
        #endregion

        #region Methods Set
        public void SetActiveMove(bool isActive)
        {
            _isActive = isActive;
        }
        public void SetKinimaticRigidBody(bool isActive)
        {
            _rb.isKinematic = isActive;
        }
        #endregion

        private void Move()
        {
            transform.Translate(Vector2.right * _speed * Time.fixedDeltaTime);
        }
    }
}