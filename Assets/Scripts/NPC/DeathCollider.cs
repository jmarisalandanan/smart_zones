using UnityEngine;

namespace Magicspace.SmartZones
{
    public class DeathCollider : MonoBehaviour
    {
        public LayerMask layer;

        private void OnTriggerEnter(Collider col)
        {
            if (1 << col.gameObject.layer == layer.value)
            {
                Destroy(col.gameObject);
            }
        }
    }
}
