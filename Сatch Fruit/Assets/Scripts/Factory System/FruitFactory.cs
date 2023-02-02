using UnityEngine;
using FruitSystem;
using PlayerSystem;

namespace FactorySystem
{
    public class FruitFactory : ObjectsAbstractFactory
    {
        private const string STR_FRUIT_PREFIX = "Fruit/";

        private Transform[] _spawnPoint;
        private TypeFruit _typeFruit;

        private int _countSpawnsPoint;
        private int _countTypesFruit;

        public FruitFactory(Transform[] points)
        {
            _spawnPoint = points;
            _countSpawnsPoint = _spawnPoint.Length;
            _countTypesFruit = System.Enum.GetNames(typeof(TypeFruit)).Length;
        }

        public override GameObject CreateObject()
        {
            int randSpawnPos = Random.Range(0, _countSpawnsPoint);
            int randTypeFruit = Random.Range(0, _countTypesFruit);

            _typeFruit = (TypeFruit)randTypeFruit;
            var _fruitPrefab = Resources.Load<GameObject>(STR_FRUIT_PREFIX + _typeFruit.ToString());

            var fruit = Instantiate(_fruitPrefab, _spawnPoint[randSpawnPos].position, _fruitPrefab.transform.rotation);
            fruit.gameObject.transform.SetParent(_spawnPoint[randSpawnPos]);

            return fruit;
        }
    }
}