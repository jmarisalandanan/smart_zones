using UnityEngine;

namespace Magicspace.SmartZones
{
    [RequireComponent(typeof(Animator))]
    public class NPCAnimatorControl : MonoBehaviour
    {
        private readonly int IS_ACTING = Animator.StringToHash("isActing");
        private readonly int IS_WALKING = Animator.StringToHash("isWalking");

        private Animator cachedAnimator;
        private AnimatorOverrideController newAnimator;
        private bool queuedAct;

        public void OnRoleChange(Role role)
        {
            newAnimator = role.roleAnimator;
        }

        public void OnRoleRelease()
        {
            cachedAnimator.SetBool(IS_ACTING, false);
        }

        public void OnStopMoving()
        {
            OnMoveStateChange(false);
            //on stop, do all actions
            if (newAnimator != null)
            {
                cachedAnimator.runtimeAnimatorController = newAnimator;
                newAnimator = null;
            }

            if (queuedAct)
            {
                queuedAct = false;
                cachedAnimator.SetBool(IS_ACTING, true);
            }
        }

        public void OnMoveStateChange(bool value)
        {
            cachedAnimator.SetBool(IS_WALKING, value);
        }

        public void OnRoleQueued()
        {
            queuedAct = true;
        }

        private void Awake()
        {
            cachedAnimator = GetComponent<Animator>();
        }
    }
}
