using System.Linq;
using UnityEngine;
using UnityEngine.Events;

namespace Magicspace.SmartZones
{
    public class Actor : MonoBehaviour
    {
        [SerializeField] private Role[] roles;

        [SerializeField] private RoleEvent onRoleAssigned;
        [SerializeField] private UnityEvent onDoAct;
        [SerializeField] private UnityEvent onRoleReleased;

        public bool HasRole { get; private set; }

        public bool CanDoRole(Role role)
        {
            return roles.Any(t => t.roleID == role.roleID);
        }

        public void Assign(Role role)
        {
            HasRole = true;
            onRoleAssigned.Invoke(role);
        }

        public void Release()
        {
            HasRole = false;
            onRoleReleased.Invoke();
        }

        public void DoAct()
        {
            onDoAct.Invoke();
        }
    }
}
