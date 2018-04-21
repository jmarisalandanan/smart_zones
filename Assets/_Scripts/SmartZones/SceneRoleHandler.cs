using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SceneRoleHandler : MonoBehaviour {
    [SerializeField]
    private SceneRole[] sceneRoles;

    [SerializeField]
    private NPCRuntimeTable npcSets;

    private int currentAssignedRoles = 0;
    private int requiredRoles = 0;

    void Awake()
    {
        DetermineEssentialRoles();
    }

    private void DetermineEssentialRoles()
    {
        for(int i = 0; i < sceneRoles.Length; i ++)
        {
            if (sceneRoles[i].isRoleEssential)
                requiredRoles++;
        }
    }

    public bool AssignActorToRole(Actor actor)
    {
        for(int i = 0; i < sceneRoles.Length; i ++)
        {
            if(!sceneRoles[i].isRoleTaken && actor.CanDoRole(sceneRoles[i].role)){
                sceneRoles[i].SetActor(actor);
                npcSets.KeyPair[actor.gameObject.GetInstanceID()].navigation.SetTarget(sceneRoles[i].transform);
                if(sceneRoles[i].isRoleEssential)
                    currentAssignedRoles++;
                return true;
            }
        }
        return false;
    }

    public bool isRoleReady()
    {
        return currentAssignedRoles >= requiredRoles;
    }

    public void StartScene()
    {
        for(int i = 0; i < sceneRoles.Length; i ++)
        {
            if (sceneRoles[i].isRoleTaken)
                sceneRoles[i].StartAct();
        }
    }

    public void ReleaseAllRoles()
    {
        currentAssignedRoles = 0;
        for(int i = 0; i < sceneRoles.Length; i ++)
        {
            if(sceneRoles[i].isRoleTaken)
                sceneRoles[i].ReleaseActor();
        }
    }

}
