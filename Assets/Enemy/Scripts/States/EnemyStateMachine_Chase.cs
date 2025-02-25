using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class EnemyStateMachine : MonoBehaviour
{
	private void ChaseState()
	{
		// chạy quá xa hoặc khoảng cách giữa 2 bên ngày càng xa thì phải đổi state
		if (CheckDistanceToTarget(spawnPoint) >= chasingDistance)
		{
			Debug.Log("max Distance Change back spawn point state");
			ChangeState(EnemyState.BackSpawnPoint);
			return;
		}
		// nếu vào đúng khoảng cách tấn công thì đổi state
		if (PlayerEnterArea(enemyInfomation.AtkRange))
		{
			agent.ResetPath();
			ChangeState(EnemyState.Attack);
		}
		else
		{
			MoveToTarget(enemyInfomation.EnemySpeed * 2, spawner.playerPosition.position);
			var moveX = enemyDirection.x >= 0 ? 2 : -2; // vì chase (truy duổi) nên sẽ chạy nên set = 2 và -2
			var moveZ = enemyDirection.z >= 0 ? 2 : -2;
			LoadAnim("MoveX", moveX);
			LoadAnim("MoveZ", moveZ);
		}
	}
}
