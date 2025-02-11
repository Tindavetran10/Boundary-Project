using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class AttackAgent : MonoBehaviour
{
    [SerializeField] private EnemyChasingAgent _chasingAgent;
	[SerializeField] private float _attackingRange;
	[SerializeField] private Animator _animator;

	public bool IsInAttackingRange => _chasingAgent.Distance <= _attackingRange;

	public void StartAttack() => _animator.CrossFade("Attack", 0.1f, 0, 0);

	public void UpdateAttack()
	{
		var stateInfo = _animator.GetCurrentAnimatorStateInfo(0);
		if (stateInfo.IsName("Attack") && stateInfo.normalizedTime >= 1)
		{
			KillEnemy();
		}
	}

	private void KillEnemy() => Destroy(_chasingAgent.CurrentEnemy.gameObject);

	public void StopAttack() => enabled = false;
}
