using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Config/SmartZones/Role")]
public class Role : ScriptableObject {
    public int roleID;
    public AnimatorOverrideController roleAnimator;
}
