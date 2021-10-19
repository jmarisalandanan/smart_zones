using UnityEngine;

namespace Magicspace.SmartZones
{
    public class SceneRoleHandler : MonoBehaviour
    {
        [SerializeField] private SceneRole[] sceneRoles;
        [SerializeField] private NPCRuntimeTable npcSets;

        private int filledEssentialRoles;
        private int requiredRolesToStart;

        public bool AssignActorToRole(Actor actor)
        {
            foreach (var t in sceneRoles)
            {
                if (filledEssentialRoles < requiredRolesToStart)
                {
                    if (!t.isRoleEssential)
                    {
                        continue;
                    }
                }

                if (!t.isRoleTaken && actor.CanDoRole(t.role))
                {
                    t.SetActor(actor);
                    npcSets.KeyPair[actor.gameObject.GetInstanceID()].navigation.SetTarget(t.transform);
                    if (t.isRoleEssential)
                    {
                        filledEssentialRoles++;
                    }
                    return true;
                }
            }

            return false;
        }

        public bool IsRoleReady()
        {
            return filledEssentialRoles >= requiredRolesToStart;
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
            filledEssentialRoles = 0;
            foreach (var t in sceneRoles)
            {
                if (t.isRoleTaken)
                {
                    t.ReleaseActor();
                }
            }
        }

        private void DetermineEssentialRoles()
        {
            foreach (var t in sceneRoles)
            {
                if (t.isRoleEssential)
                {
                    requiredRolesToStart++;
                }
            }
        }

        private void Awake()
        {
            DetermineEssentialRoles();
        }
    }
}
