using UnityEngine;

namespace Magicspace.SmartZones
{
    public class SceneRole : MonoBehaviour
    {
        public Role role;
        public bool isRoleTaken;
        public bool isRoleEssential;

        private Actor currentActor;

        private void OnDrawGizmos()
        {
            Gizmos.color = Color.blue;
            Gizmos.DrawWireSphere(transform.position, 0.3f);
        }

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
    }
}