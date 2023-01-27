using UnityEngine;

public class ConveyorBelt : MonoBehaviour
{
    [System.Serializable]
    public class Belt
    {
        public MeshRenderer meshRenderer = null;
        public float speed = 0f;
        [HideInInspector] public Vector2 offset;
        [HideInInspector] public Material mat;
    }

    [SerializeField] private Belt _belt;

    private void Start()
    {
        _belt.offset = Vector2.zero;
        _belt.mat = _belt.meshRenderer.material;
    }

    private void FixedUpdate()
    {
        _belt.offset.y += _belt.speed * Time.fixedDeltaTime;
        _belt.mat.mainTextureOffset = _belt.offset;
    }
}