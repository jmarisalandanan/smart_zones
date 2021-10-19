using System.Linq;
using UnityEngine;
using UnityEngine.Events;

public class Actor : MonoBehaviour
{
    [SerializeField] private Role[] roles;

    public RoleEvent onRoleAssigned;
    public UnityEvent onDoAct;
    public UnityEvent onRoleReleased;

    public bool hasRole;

    public bool CanDoRole(Role role)
    {
        return roles.Any(t => t.roleID == role.roleID);
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
