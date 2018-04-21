using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Actor : MonoBehaviour {

    [SerializeField]
    private Role[] roles;

    public RoleEvent onRoleAssigned;
    public UnityEvent onDoAct;
    public UnityEvent onRoleReleased;

    public bool hasRole;

    public bool CanDoRole(Role role)
    {
        for(int i = 0; i < roles.Length; i ++)
        {
            if(roles[i].roleID == role.roleID)
            {
                return true;
            }
        }
        return false;
    }

    public void Assign(Role role)
    {
        hasRole = true;
        onRoleAssigned.Invoke(role);
    }

    public void Release()
    {
        hasRole = false;
        onRoleReleased.Invoke();
    }

    public void DoAct()
    {
        onDoAct.Invoke();
    }
}
