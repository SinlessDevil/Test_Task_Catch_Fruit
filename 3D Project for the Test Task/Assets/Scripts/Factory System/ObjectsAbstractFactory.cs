using UnityEngine;

namespace FactorySystem
{
    public abstract class ObjectsAbstractFactory : MonoBehaviour
    {
        public abstract GameObject CreateObject();
    }
}