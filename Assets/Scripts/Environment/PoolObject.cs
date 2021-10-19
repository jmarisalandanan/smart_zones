using UnityEngine;

namespace MagicSpace.Utilities
{
    public class PoolObject : MonoBehaviour
    {
        private Transform cachedTransform;

        public void Spawn()
        {
            cachedTransform.localPosition = Vector3.zero;
        }

        private void Awake()
        {
            cachedTransform = transform;
        }
    }
}
