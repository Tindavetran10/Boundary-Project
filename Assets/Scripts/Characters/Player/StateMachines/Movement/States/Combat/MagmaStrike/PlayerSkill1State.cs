using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerSkill1State : PlayerCombatState
{
    public PlayerMagmaStrikeData magmaStrikeData;

    public Transform firePoint;

    public Coroutine MagmaStrikeCoroutine;

    public float effectDuration = 6f;

    public PlayerSkill1State(PlayerMovementStateMachine playerMovementStateMachine) : base(playerMovementStateMachine)
    {
        magmaStrikeData = movementData.MagmaStrikeData;
    }

    #region IState Methods
    public override void Enter()
    {
        stateMachine.ReusableData.MovementSpeedModifier = 0f;

        stateMachine.Player.Rigidbody.velocity = Vector3.zero;

        base.Enter();

        StartAnimation(stateMachine.Player.AnimationData.MagmaStrikeAttackParameterHash);

        firePoint = stateMachine.Player.transform;
        firePoint.transform.rotation = stateMachine.Player.transform.rotation;

        MagmaStrike();
    }

    public override void Exit()
    {
        base.Exit();

        

        StopAnimation(stateMachine.Player.AnimationData.MagmaStrikeAttackParameterHash);
    }

    public override void Update()
    {
        base.Update();
    }

    public override void OnAnimationTransitionEvent()
    {
        if (stateMachine.ReusableData.MovementInput == Vector2.zero)
        {
            stateMachine.ChangeState(stateMachine.IdlingState);
            return;
        }

        if (stateMachine.ReusableData.ShouldWalk)
        {
            stateMachine.ChangeState(stateMachine.WalkingState);
            return;
        }

        stateMachine.ChangeState(stateMachine.RunningState);
    }
    #endregion

    #region Main Methods
    private void MagmaStrike()
    {
        stateMachine.Player.RunCoroutine(SpawnMagmaStrike());
    }

    IEnumerator SpawnMagmaStrike()
    {
        yield return new WaitForSeconds(magmaStrikeData.WaitingTImeSpawnVFX);
        InstantiateProjectile();
    }

    private void InstantiateProjectile()
    {
        GameObject magmaStrike = Object.Instantiate(magmaStrikeData.Effect_MagmaStrike, firePoint.position, firePoint.rotation);
        //magmaStrike.GetComponent<Rigidbody>().velocity = (stateMachine.Player.transform.forward).normalized * magmaStrikeData.Effect_Speed;
        stateMachine.Player.DestroyEffect(magmaStrike, effectDuration);
    }
    #endregion

    #region Reusable Methods
    protected override void AddInputActionsCallBack()
    {
        base.AddInputActionsCallBack();
    }

    protected override void RemoveInputActionsCallBack()
    {
        base.RemoveInputActionsCallBack();
    }
    #endregion

    #region Input Methods
    protected override void OnSkill1State(InputAction.CallbackContext context)
    {
        
    }
    #endregion
}
