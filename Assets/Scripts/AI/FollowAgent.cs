using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class FollowAgent : MonoBehaviour
{
    [SerializeField] private Transform _target;
    [SerializeField] private float _reachingDistance = 1f;
    [SerializeField] private NavMeshAgent _navMeshAgent;
    [SerializeField] private Animator _animator;

    public float Distance => Vector3.Distance(transform.position, _target.position);

    public bool IsTargetReached => Distance <= _reachingDistance;

    public void StartFollow()
    {
        _animator.CrossFade("Follow", 0.1f);
		_navMeshAgent.enabled = true;
	}

	public void FollowTarget() => _navMeshAgent.SetDestination(_target.position);

	public void Stop() => _navMeshAgent.enabled = false;
}
