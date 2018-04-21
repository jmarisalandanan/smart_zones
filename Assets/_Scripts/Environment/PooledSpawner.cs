using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Timers;

public class PooledSpawner : MonoBehaviour {

    [SerializeField]
    private GameObject[] objectsToSpawn;

    [SerializeField]
    private FloatVariable minSpawnInterval;

    [SerializeField]
    private FloatVariable maxSpawnInterval;

    [SerializeField]
    private Transform initialDestination;

    [SerializeField]
    private NPCRuntimeTable npcRuntimeSet;

    private Transform cachedTransform;

    void Awake()
    {
        cachedTransform = this.transform;
    }

    void Start()
    {
        Spawn();
    }

    private void Spawn()
    {
        GameObject go = GameObject.Instantiate(objectsToSpawn[Random.Range(0,objectsToSpawn.Length)], cachedTransform);
        go.transform.localPosition = Vector3.zero;
        npcRuntimeSet.KeyPair[go.GetInstanceID()].navigation.SetTarget(initialDestination);
        TimersManager.SetTimer(this, Random.Range(minSpawnInterval.value, maxSpawnInterval.value), Spawn);
    }

}
