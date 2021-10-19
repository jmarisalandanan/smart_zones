using UnityEngine;

public class PoolObject : MonoBehaviour
{
    private Transform cachedTransform;

    public bool isSpawned { private set; get; }

    private void Awake()
    {
        cachedTransform = transform;
    }

    public void Spawn()
    {
        isSpawned = true;
        cachedTransform.localPosition = Vector3.zero;
    }
}