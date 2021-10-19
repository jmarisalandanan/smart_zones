using System.Linq;
using Timers;
using UnityEngine;
using UnityEngine.Events;

public class RoleAssigner : MonoBehaviour
{
    [SerializeField] private SceneRoleHandler[] sceneRoles;
    [SerializeField] private NPCRuntimeTable npcSets;
    [SerializeField] private FloatVariable sceneDuration;
    [SerializeField] private FloatVariable reactivationTime;

    public UnityEvent onSceneActivate;
    public UnityEvent onSceneEnd;

    private bool sceneOngoing;

    public void OnNPCEnteredZone(int id)
    {
        var newActor = npcSets.KeyPair[id].actor;

        if (!newActor.hasRole)
        {
            FindAssignment(newActor);
        }

        CheckIfSceneReady();
    }

    private void FindAssignment(Actor actor)
    {
        sceneRoles.Select(t => t.AssignActorToRole(actor)).Any(assigned => assigned);
    }

    private void StartZone()
    {
        foreach (var t in sceneRoles)
        {
            t.StartScene();
        }

        if (!sceneOngoing)
        {
            sceneOngoing = true;
            TimersManager.SetTimer(this, sceneDuration.value, EndScene);
        }
    }

    private void CheckIfSceneReady()
    {
        if (sceneRoles.Any(t => !t.IsRoleReady()))
        {
            return;
        }

        StartZone();
    }

    private void EndScene()
    {
        sceneOngoing = false;
        foreach (var t in sceneRoles)
        {
            t.ReleaseAllRoles();
        }

        onSceneEnd.Invoke();
        TimersManager.SetTimer(this, reactivationTime.value, ReactivateScene);
    }

    private void ReactivateScene()
    {
        onSceneActivate.Invoke();
    }
}
