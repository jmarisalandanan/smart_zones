using UnityEngine;

[CreateAssetMenu(fileName = "GeneralTable", menuName = "Config/RoleTable")]
public class ActorRuntimeTable : RuntimeTable<int, Actor>
{
    public Actor GetObject(int instanceId)
    {
        return KeyPair[instanceId];
    }
}