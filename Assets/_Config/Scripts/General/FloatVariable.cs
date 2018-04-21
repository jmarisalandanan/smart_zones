using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Config/Variables/Float")]
public class FloatVariable : ScriptableObject
{
    public float value;
    [HideInInspector]
    public float localValue;
}
