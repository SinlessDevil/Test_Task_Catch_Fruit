using UnityEngine;
using FruitSystem;

namespace FactorySystem
{
    public class FruitFactory : ObjectsAbstractFactory
    {
        private const string STR_FRUIT_PREFIX = "Fruit/";

        private Transform[] _spawnPoint;
        private TypeFruit _typeFruit;

        public FruitFactory(Transform[] points)
        {
            _spawnPoint = points;
        }

        public override GameObject CreateObject()
        {
            int randSpawnPos = Random.Range(0, _spawnPoint.Length);
            int randTypeFruit = Random.Range(0, 4);

            _typeFruit = (TypeFruit)randTypeFruit;
            var _fruitPrefab = Resources.Load<GameObject>(STR_FRUIT_PREFIX + _typeFruit.ToString());

            var fruit = Instantiate(_fruitPrefab, _spawnPoint[randSpawnPos].position, Quaternion.identity);

            return fruit;
        }
    }
}