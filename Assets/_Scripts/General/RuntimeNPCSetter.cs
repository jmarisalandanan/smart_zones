using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RuntimeNPCSetter : MonoBehaviour
{
    [SerializeField]
    private NPCRuntimeTable npcRuntimeTable;

    private NPC npc;

    void Awake()
    {
        npc = new NPC();
        npc.actor = this.GetComponent<Actor>();
        npc.navigation = this.GetComponent<NPCNavigation>();
    }

    void OnEnable()
    {
        npcRuntimeTable.Add(this.gameObject.GetInstanceID(), npc);
    }

    void OnDisable()
    {
        npcRuntimeTable.Remove(this.gameObject.GetInstanceID());
    }
}
