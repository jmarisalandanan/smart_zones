using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Events;

[RequireComponent(typeof(NavMeshAgent))]
public class NPCNavigation : MonoBehaviour
{
    public BoolEvent onNPCMove;
    public UnityEvent onDestinationReached;
    private NavMeshAgent cachedNavMeshAgent;
    private Transform cachedTransform;
    private Transform currentTarget;

    private Transform defaultTargetDestination;
    private bool isNPCMoving;

    private void Awake()
    {
        cachedNavMeshAgent = GetComponent<NavMeshAgent>();
        cachedTransform = transform;
    }

    private void Update()
    {
        var pathInProgress = cachedNavMeshAgent.velocity.magnitude > 0.5f &&
                             cachedNavMeshAgent.remainingDistance > cachedNavMeshAgent.radius;
        CheckMoveState(pathInProgress);
        if (!pathInProgress)
        {
            onDestinationReached.Invoke();
            RotateTowards(currentTarget);
        }
    }

    public void SetTarget()
    {
        if (defaultTargetDestination != null)
            cachedNavMeshAgent.destination = defaultTargetDestination.position;
    }

    public void SetTarget(Transform target)
    {
        if (defaultTargetDestination == null)
            defaultTargetDestination = target;
        cachedNavMeshAgent.destination = target.position;
        currentTarget = target;
    }

    private void CheckMoveState(bool newState)
    {
        if (newState != isNPCMoving)
        {
            isNPCMoving = newState;
            onNPCMove.Invoke(isNPCMoving);
        }
    }

    private void RotateTowards(Transform target)
    {
        cachedTransform.rotation = Quaternion.Slerp(cachedTransform.rotation, target.rotation, Time.deltaTime * 5f);
    }
}