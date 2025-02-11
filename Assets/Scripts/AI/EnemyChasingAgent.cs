using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyChasingAgent : MonoBehaviour
{
	[SerializeField] private float _chasingRange;
	[SerializeField] private float _attackingRange;
	[SerializeField] private NavMeshAgent _navMeshAgent;

	private Enemy _currentEnemy;

	public bool IsInChasingRange => Distance <= _chasingRange;
	public bool IsInAttackingRange => Distance <= _attackingRange;
	private float Distance => (_currentEnemy == null) ? float.MaxValue: Vector3.Distance(transform.position, _currentEnemy.transform.position);

	public bool HasEnemy => _currentEnemy != null;

	private void Update()
	{
		if (_currentEnemy == null)
		{
			LookForNearbyEnemy();
		}
		else
		{
			CheckIfEnemyStillValid();
		}
	}

	private void LookForNearbyEnemy()
	{
		var enemies = FindObjectsOfType<Enemy>();
		foreach (var enemy in enemies)
		{
			if (Vector3.Distance(transform.position, enemy.transform.position) < _chasingRange)
			{
				_currentEnemy = enemy;
				return;
			}
		}
	}

	private void CheckIfEnemyStillValid()
	{
		if (!IsInChasingRange)
		{
			_currentEnemy = null;
		}
	}

	public void ChaseEnemy()
	{
		_navMeshAgent.enabled = true;
		_navMeshAgent.SetDestination(_currentEnemy.transform.position);
	}

	public void Stop() => _navMeshAgent.enabled = false;
}
