using UnityEngine;

[CreateAssetMenu(menuName = "Config/Variables/Int")]
public class IntVariable : ScriptableObject
{
    public int value;

    [HideInInspector] public int localValue;
}