using UnityEngine;

[CreateAssetMenu(fileName = "GeneralTable", menuName = "Config/ObjectTable")]
public class ObjectRuntimeTable : RuntimeTable<int, GameObject>
{
    public GameObject GetObject(int instanceId)
    {
        return KeyPair[instanceId];
    }
}