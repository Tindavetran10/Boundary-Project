using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class EnemyStateMachine : MonoBehaviour
{
	private void BackSpawnPointState()
	{
		if (CheckDistanceToTarget(spawnPoint) <= 0.5f)
		{
			ResetTimer();
			ChangeState(EnemyState.Patrol);
		}
		MoveToTarget(enemyInfomation.EnemySpeed, spawnPoint);
		var moveX = enemyDirection.x >= 0 ? 1 : -1; // vì patrolling (tuần tra) nên sẽ đi bộ nên set = 1 và -1
		var moveZ = enemyDirection.z >= 0 ? 1 : -1;
		LoadAnim("MoveX", moveX);
		LoadAnim("MoveZ", moveZ);

		if (PlayerEnterArea(enemyInfomation.warningArea))
		{
			Vector3 enemyDirection = spawnPoint - transform.position;
			float angle = Vector3.Angle(transform.forward, enemyDirection);
			if (angle < 10f)
			{
				agent.ResetPath();
				Debug.Log("Change warning state");
				LoadAnim("isWarning", true);
				LoadAnim("isMove", false);
				ChangeState(EnemyState.Warning);
			}
		}
	}

}
