using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class NPCNavigation : MonoBehaviour {

    public BoolEvent onNPCMove;
    public UnityEvent onDestinationReached;

    private Transform defaultTargetDestination;
    private Transform cachedTransform;
    private Transform currentTarget;
    private NavMeshAgent cachedNavMeshAgent;
    private bool isNPCMoving = false;

    void Awake()
    {
        cachedNavMeshAgent = this.GetComponent<NavMeshAgent>();
        cachedTransform = this.transform;
    }

    void Update()
    {
        bool pathInProgress = cachedNavMeshAgent.velocity.magnitude > 0.5f && cachedNavMeshAgent.remainingDistance > cachedNavMeshAgent.radius;
        CheckMoveState(pathInProgress);
        if (!pathInProgress)
        {
            onDestinationReached.Invoke();
            RotateTowards(currentTarget);
        }
    }

    public void SetTarget()
    {
        if(defaultTargetDestination != null)
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
        if(newState != isNPCMoving)
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
