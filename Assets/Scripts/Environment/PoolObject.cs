using UnityEngine;

namespace MagicSpace.Utilities
{
    public class PoolObject : MonoBehaviour
    {
        private Transform cachedTransform;

        private void Awake()
        {
            cachedTransform = transform;
        }

        public void Spawn()
        {
            cachedTransform.localPosition = Vector3.zero;
        }
    }
}
