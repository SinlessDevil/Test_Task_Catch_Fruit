using UnityEngine;

namespace FruitSystem
{
    public class CollisonDestroy : MonoBehaviour
    {
        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.TryGetComponent(out Fruit fruit))
            {
                Destroy(other.gameObject);
            }
    }
    }
}