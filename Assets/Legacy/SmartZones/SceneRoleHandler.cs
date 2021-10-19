using UnityEngine;

public class SceneRoleHandler : MonoBehaviour
{
    [SerializeField] private SceneRole[] sceneRoles;
    [SerializeField] private NPCRuntimeTable npcSets;

    private int currentAssignedRoles;
    private int requiredRoles;

    private void Awake()
    {
        DetermineEssentialRoles();
    }

    private void DetermineEssentialRoles()
    {
        foreach (var t in sceneRoles)
        {
            if (t.isRoleEssential)
            {
                requiredRoles++;
            }
        }
    }

    public bool AssignActorToRole(Actor actor)
    {
        foreach (var t in sceneRoles)
        {
            if (!t.isRoleTaken && actor.CanDoRole(t.role))
            {
                t.SetActor(actor);
                npcSets.KeyPair[actor.gameObject.GetInstanceID()].navigation.SetTarget(t.transform);
                if (t.isRoleEssential)
                    currentAssignedRoles++;
                return true;
            }
        }
        return false;
    }

    public bool IsRoleReady()
    {
        return currentAssignedRoles >= requiredRoles;
    }

    public void StartScene()
    {
        foreach (var t in sceneRoles)
        {
            if (t.isRoleTaken)
            {
                t.StartAct();
            }
        }
    }

    public void ReleaseAllRoles()
    {
        currentAssignedRoles = 0;
        foreach (var t in sceneRoles)
        {
            if (t.isRoleTaken)
            {
                t.ReleaseActor();
            }
        }
    }
}
