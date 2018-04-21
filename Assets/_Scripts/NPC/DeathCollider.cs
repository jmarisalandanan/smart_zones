using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathCollider : MonoBehaviour {
    public LayerMask layer;

    void OnTriggerEnter(Collider col)
    {
        if (1 << col.gameObject.layer == layer.value)
        {
            Destroy(col.gameObject);
        }
    }
}
