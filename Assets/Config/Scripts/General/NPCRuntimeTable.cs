using Magicspace.SmartZones;
using UnityEngine;

[CreateAssetMenu(fileName = "GeneralTable", menuName = "Config/NPCTable")]
public class NPCRuntimeTable : RuntimeTable<int, NPC>
{
    public NPC GetObject(int instanceId)
    {
        return KeyPair[instanceId];
    }
}