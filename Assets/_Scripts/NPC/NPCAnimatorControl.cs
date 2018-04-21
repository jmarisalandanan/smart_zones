using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class NPCAnimatorControl : MonoBehaviour {
    private Animator cachedAnimator;

    private AnimatorOverrideController newAnimator;

    private readonly int IS_WALKING = Animator.StringToHash("isWalking");
    private readonly int IS_ACTING = Animator.StringToHash("isActing");

    private bool queuedAct = false;

    void Awake()
    {
        cachedAnimator = this.GetComponent<Animator>();
    }

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
}
