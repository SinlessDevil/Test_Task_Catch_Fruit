using System.Collections;
using UnityEngine;

namespace FactorySystem
{
    public class SpawnObject : MonoBehaviour
    {
        [SerializeField] private Transform[] points;
        [SerializeField] private float _waitTime;
        private ObjectsAbstractFactory _objectsAbstractFactory;

        private void Start()
        {
            _objectsAbstractFactory = new FruitFactory(points);
            StartCoroutine(SpawnObjectsRoutine());
        }

        private IEnumerator SpawnObjectsRoutine()
        {
            while (true)
            {
                yield return new WaitForSeconds(_waitTime);
                _objectsAbstractFactory.CreateObject();
            }
        }
    }
}