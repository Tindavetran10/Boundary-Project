using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class NavigationAgent : MonoBehaviour
{
    [SerializeField] private NavMeshAgent _agent;
	[SerializeField] private NavigationRoute _route;

	private void OnValidate() => _agent = GetComponent<NavMeshAgent>();

	private void Start() => StartCoroutine(FollowPath());

	private IEnumerator FollowPath()
	{
		transform.position = _route[0];
		for (int i = 1; i < _route.WaypointCount; i++)
		{
			_agent.SetDestination(_route[i]);
			yield return new WaitUntil(() => IsDestinationReached(i));
		}
	}

	private bool IsDestinationReached(int index)
	{
		var distance = Vector3.Distance(transform.position, _route[index]);
		return distance < 0.1f;
	}
}
