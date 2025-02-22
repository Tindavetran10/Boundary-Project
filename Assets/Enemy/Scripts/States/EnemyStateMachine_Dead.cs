using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class EnemyStateMachine : MonoBehaviour
{
	private void DeadState()
	{
		if (isDead)
		{
			isDead = false;
			animator.enabled = false;
			animator.enabled = true;
			animator.Play("Death", 0, 0f);
			StartCoroutine(WaitingDeadEnd());
		}
	}
	IEnumerator WaitingDeadEnd()
	{
		yield return new WaitForSeconds(animator.GetCurrentAnimatorStateInfo(0).length + 3f);
		DestroyEnemy();
	}
}
