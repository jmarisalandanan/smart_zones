using UnityEngine;

public class RuntimeNPCSetter : MonoBehaviour
{
    [SerializeField] private NPCRuntimeTable npcRuntimeTable;

    private NPC npc;

    private void Awake()
    {
        npc = new NPC
        {
            actor = GetComponent<Actor>(),
            navigation = GetComponent<NPCNavigation>(),
        };
    }

    private void OnEnable()
    {
        npcRuntimeTable.Add(gameObject.GetInstanceID(), npc);
    }

    private void OnDisable()
    {
        npcRuntimeTable.Remove(gameObject.GetInstanceID());
    }
}
