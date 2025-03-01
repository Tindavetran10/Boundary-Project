using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class EnemyStateMachine : MonoBehaviour
{
	//điều khiển warning state
	private void WarningState()
	{
		// nếu player tiến vào vùng truy đuổi
		if (PlayerEnterArea(enemyInfomation.chaseArea))
		{
			agent.Resume();
			Debug.Log("Change chase state");
			LoadAnim("isMove", true);
			LoadAnim("isWarning", false);
			ChangeState(EnemyState.Chase);
			return;
		}
		//nếu player ra khỏi vùng cảnh giác
		if (!PlayerEnterArea(enemyInfomation.warningArea))
		{
			agent.Resume();
			Debug.Log("Change idle state");
			LoadAnim("IdleState", 1);
			LoadAnim("isMove", false);
			LoadAnim("isWarning", false);
			ChangeState(EnemyState.Idle);
			return;
		}
		RotateToTarget(spawner.playerPosition.position);
	}
}
