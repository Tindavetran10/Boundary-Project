using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NavigationAnimation : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    [SerializeField] private NavMeshAgent _agent;

	private readonly int CurrentSpeedHash = Animator.StringToHash("CurrentSpeed");

	private void Update()
	{
		var currentSpeed = _agent.velocity.magnitude;
		_animator.SetFloat(CurrentSpeedHash, currentSpeed);
	}
}
