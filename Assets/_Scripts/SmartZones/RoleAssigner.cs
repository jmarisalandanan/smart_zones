using UnityEngine;
using UnityEngine.Events;

using Timers;

public class RoleAssigner : MonoBehaviour
{
    [SerializeField]
    private SceneRoleHandler[] sceneRoles;

    [SerializeField]
    private NPCRuntimeTable npcSets;

    [SerializeField]
    private FloatVariable sceneDuration;

    [SerializeField]
    private FloatVariable reactivationTime;

    private bool sceneOngoing = false;

    public UnityEvent onSceneActivate;
    public UnityEvent onSceneEnd;

    public void OnNPCEnteredZone(int id)
    {
        Actor newActor = npcSets.KeyPair[id].actor;

        if(!newActor.hasRole)
            FindAssignment(newActor);

        CheckIfSceneReady();
    }

    private void FindAssignment(Actor actor)
    {
        for(int i = 0; i < sceneRoles.Length; i ++)
        {
            bool assigned = sceneRoles[i].AssignActorToRole(actor);
            if (assigned)
                return;
        }
    }

    private void StartZone()
    {
        for (int i = 0; i < sceneRoles.Length; i++)
        {
            sceneRoles[i].StartScene();
        }

        if (!sceneOngoing) {
            sceneOngoing = true;
            TimersManager.SetTimer(this, sceneDuration.value, EndScene);
        }
    }

    private void CheckIfSceneReady()
    {
        for(int i = 0; i <sceneRoles.Length; i++)
        {
            if (!sceneRoles[i].isRoleReady())
                return;
        }

        StartZone();
    }

    private void EndScene()
    {
        sceneOngoing = false;
        for(int i = 0; i < sceneRoles.Length; i ++)
        {
            sceneRoles[i].ReleaseAllRoles();
        }
        onSceneEnd.Invoke();
        TimersManager.SetTimer(this, reactivationTime.value, ReactivateScene);
    }

    private void ReactivateScene()
    {
        onSceneActivate.Invoke();
    }
}
