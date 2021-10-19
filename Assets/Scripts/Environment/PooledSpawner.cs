using Timers;
using UnityEngine;

namespace MagicSpace.Utilities
{
    public class PooledSpawner : MonoBehaviour
    {
        [SerializeField] private GameObject[] objectsToSpawn;
        [SerializeField] private FloatVariable minSpawnInterval;
        [SerializeField] private FloatVariable maxSpawnInterval;
        [SerializeField] private Transform initialDestination;
        [SerializeField] private NPCRuntimeTable npcRuntimeSet;

        private Transform cachedTransform;

        private void Spawn()
        {
            var go = Instantiate(objectsToSpawn[Random.Range(0, objectsToSpawn.Length)], cachedTransform);
            go.transform.localPosition = Vector3.zero;
            npcRuntimeSet.KeyPair[go.GetInstanceID()].navigation.SetTarget(initialDestination);
            TimersManager.SetTimer(this, Random.Range(minSpawnInterval.value, maxSpawnInterval.value), Spawn);
        }

        private void Awake()
        {
            cachedTransform = transform;
        }

        private void Start()
        {
            Spawn();
        }
    }
}
