using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolObject : MonoBehaviour {

    public bool isSpawned { private set; get; }

    private Transform cachedTransform;

    void Awake()
    {
        cachedTransform = this.transform;
    }

    public void Spawn()
    {
        isSpawned = true;
        cachedTransform.localPosition = Vector3.zero;
    }

}
