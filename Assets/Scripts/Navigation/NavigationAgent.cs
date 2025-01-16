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
		int index = 0;
		int direction = 1;
		transform.position = _route[index];
		while (true)
		{
			(int nextIndex, int nextDirection) = _route.NextIndex(index, direction);
			if (nextIndex == index) yield break;

			index = nextIndex;
			direction = nextDirection;
			_agent.SetDestination(_route[index]);
			yield return new WaitUntil(() => IsDestinationReached(index));
		}
	}

	private bool IsDestinationReached(int index)
	{
		var distance = Vector3.Distance(transform.position, _route[index]);
		return distance < 0.1f;
	}
}
