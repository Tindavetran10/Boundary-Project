using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class EnemyStateMachine : MonoBehaviour
{
	//điều khiển idle state
	private void IdleState()
	{
		if (PlayerEnterArea(enemyInfomation.warningArea))
		{
			Debug.Log("Change warning state");
			LoadAnim("isWarning", true);
			ChangeState(EnemyState.Warning);
		}
		else
		{
			IdleCoroutine();
		}
	}

	// vòng lặp chính của idle state
	private void IdleCoroutine()
	{
		timerIdle += Time.deltaTime;
		if (!ShouldChangeState(timerIdle, timeChangePatrol))
		{
			AnimatorStateInfo currentState = animator.GetCurrentAnimatorStateInfo(0);
			if (currentState.normalizedTime >= 1 && !animator.IsInTransition(0))
			{
				LoadAnim("IdleState", 1);
			}
		}
		else
		{
			Debug.Log("Change patrolling state");
			LoadAnim("isMove", true);
			ResetTimer();
			ChangeState(EnemyState.Patrol);
		}
	}
}
