using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneRole : MonoBehaviour
{
    public Role role;
    public bool isRoleTaken = false;
    public bool isRoleEssential = false;

    private Actor currentActor;

    public void SetActor(Actor actor)
    {
        isRoleTaken = true;
        actor.Assign(role);
        currentActor = actor;
    }

    public void StartAct()
    {
        currentActor.DoAct();
    }

    public void ReleaseActor()
    {
        currentActor.Release();
        currentActor = null;
        isRoleTaken = false;
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position,0.3f);
    }
}
