using System;
using System.Collections.Generic;
using UnityEngine;
using FruitSystem;

namespace TaskSystem
{
    public class TaskGeneration : MonoBehaviour
    {
        public static event Action<List<Task>, int, int> OnAnnouncementCurrentTaskEvent;
        public event Action<Task[], int> OnDisplayTaskChangeEvent;

        [Header("---------------- Generated Task Settings ----------------")]
        [SerializeField] [Range(1,4)] private int _maxAmountTask;
        [SerializeField][Range(5, 10)] private int _maxTotalAmountFruit;
        [SerializeField] private List<TypeFruit> _typeFruit;

        private int _currentTotalAmountFruit;
        private int _currentAmountTask;
        private int _amountHealth;
        private List<Task> _tasks = new();

        private void Start()
        {
            _maxTotalAmountFruit = 10;
            RandomTaskGeneration();

            OnAnnouncementCurrentTaskEvent?.Invoke(_tasks, _currentTotalAmountFruit, _amountHealth);
            OnDisplayTaskChangeEvent?.Invoke(_tasks.ToArray(), _amountHealth);
        }

        private void RandomTaskGeneration()
        {
            while (true)
            {
                //Generate Type Fruit
                var indexFruit = UnityEngine.Random.Range(0, _typeFruit.Count);
                var typeFruit = _typeFruit[indexFruit];
                _typeFruit.RemoveAt(indexFruit);

                //Generate Amount Fruit
                var amountFruits = 0;
                if (_currentTotalAmountFruit <= 5) amountFruits = UnityEngine.Random.Range(1, 6);
                else amountFruits = UnityEngine.Random.Range(1, (_maxTotalAmountFruit - _currentTotalAmountFruit + 1));

                //Assign values to the new task
                var _newTask = new Task();
                _newTask.typeFruit = typeFruit;
                _newTask.amountFruit = amountFruits;

                //Add new Task
                _tasks.Add(_newTask);

                //Update the values
                _currentAmountTask += 1;
                _currentTotalAmountFruit += amountFruits;

                //Check Value
                if (_currentAmountTask >= _maxAmountTask || _currentTotalAmountFruit >= _maxTotalAmountFruit) break;
            }

            _amountHealth = UnityEngine.Random.Range(2, 5);
        }
    }
}