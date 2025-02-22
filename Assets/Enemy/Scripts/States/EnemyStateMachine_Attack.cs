using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class EnemyStateMachine : MonoBehaviour
{
	private void AttackState()
	{
		enemyBehaviour.CountdownTimer();
		if (!PlayerEnterArea(enemyInfomation.AtkRange))
		{
			enemyBehaviour.ExitAttackState();
			ChangeState(EnemyState.Chase);
			return;
		}
		Vector3 enemyDirection = spawner.playerPosition.position - transform.position;
		float angle = Vector3.Angle(transform.forward, enemyDirection);
		// lưu ý angle
		if (angle > 20f)
		{
			RotateToTarget(spawner.playerPosition.position);
		}
		if (!enemyBehaviour.CanAttack(enemyInfomation.EnemyAtkCd) || !enemyBehaviour.CompletedPreAtk()) return;
		enemyBehaviour.EnemyAttack();
	}
}
