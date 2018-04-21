using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RuntimeActorSetter : MonoBehaviour {
    [SerializeField]
    private ActorRuntimeTable runtimeTable;

    private Actor cachedActor;

    void Awake()
    {
        cachedActor = this.GetComponent<Actor>();
    }
    
    void OnEnable()
    {
        runtimeTable.Add(this.gameObject.GetInstanceID(), cachedActor);
    }

    void OnDisable()
    {
        runtimeTable.Remove(this.gameObject.GetInstanceID());
    }
}
