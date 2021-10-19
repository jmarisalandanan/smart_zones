using UnityEngine;

namespace Magicspace.SmartZones
{
    public class RuntimeActorSetter : MonoBehaviour
    {
        [SerializeField] private ActorRuntimeTable runtimeTable;

        private Actor cachedActor;

        private void Awake()
        {
            cachedActor = GetComponent<Actor>();
        }

        private void OnEnable()
        {
            runtimeTable.Add(gameObject.GetInstanceID(), cachedActor);
        }

        private void OnDisable()
        {
            runtimeTable.Remove(gameObject.GetInstanceID());
        }
    }
}
