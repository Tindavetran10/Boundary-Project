using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class EnemyStateMachine : MonoBehaviour
{
	//điều khiển Patrol state
	private void PatrolState()
	{
		if (PlayerEnterArea(enemyInfomation.warningArea))
		{
			Debug.Log("Change warning state");
			LoadAnim("isWarning", true);
			LoadAnim("isMove", false);
			ChangeState(EnemyState.Warning);
		}
		else
		{
			EnemyPatrolling();
		}

	}
	// vòng lặp của patrolling
	private void EnemyPatrolling()
	{
		timerPatrol += Time.deltaTime;
		if (!ShouldChangeState(timerPatrol, patrollingTime))
		{
			if (!havePatrolPoint)
			{
				RandomPatrolPpoint();
				havePatrolPoint = true;
			}
			else
			{
				MoveToTarget(enemyInfomation.EnemySpeed, patrolPoint);
				if (CheckDistanceToTarget(patrolPoint) <= 1f)
				{
					havePatrolPoint = false;
					return;
				}
				var moveX = enemyDirection.x >= 0 ? 1 : -1; // vì patrolling (tuần tra) nên sẽ đi bộ nên set = 1 và -1
				var moveZ = enemyDirection.z >= 0 ? 1 : -1;
				LoadAnim("MoveX", moveX);
				LoadAnim("MoveZ", moveZ);
			}
		}
		else
		{
			agent.ResetPath();
			ResetTimer();
			LoadAnim("IdleState", 1);
			LoadAnim("isMove", false);
			ChangeState(EnemyState.Idle);
		}
	}
	Vector3 RandomPatrolPpoint()
	{
		do
		{
			float randomX = Random.Range(-chasingDistance, chasingDistance);
			float randomZ = Random.Range(-chasingDistance, chasingDistance);
			patrolPoint = new Vector3(randomX, 0, randomZ) + spawnPoint;
		}
		while (CheckDistanceToTarget(patrolPoint) >= chasingDistance);
		return patrolPoint;

	}
}
