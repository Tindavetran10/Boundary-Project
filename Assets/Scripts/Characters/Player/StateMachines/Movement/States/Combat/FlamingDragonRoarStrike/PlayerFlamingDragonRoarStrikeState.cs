using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class PlayerFlamingDragonRoarStrikeState : PlayerCombatState
{
    public PlayerFlamingDragonRoarStrikeData flamingDragonRoarStrikeData;

    public Transform firePoint;

    public float effectDuration = 6f;

    public PlayerFlamingDragonRoarStrikeState(PlayerMovementStateMachine playerMovementStateMachine) : base(playerMovementStateMachine)
    {
        flamingDragonRoarStrikeData = movementData.FlamingDragonRoarStrikeData;
    }

    #region IState Methods
    public override void Enter()
    {
        stateMachine.ReusableData.MovementSpeedModifier = 0f;

        stateMachine.Player.Rigidbody.velocity = Vector3.zero;

        base.Enter();

        StartAnimation(stateMachine.Player.AnimationData.FlamingDragonRoarStrikeAttackParameterHash);

        firePoint = stateMachine.Player.transform.Find("FirePoint");
        firePoint.transform.rotation = stateMachine.Player.transform.rotation;

        FlamingDragonRoarStrike();
    }

    public override void Exit()
    {
        base.Exit();

        StopAnimation(stateMachine.Player.AnimationData.FlamingDragonRoarStrikeAttackParameterHash);
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
    private void FlamingDragonRoarStrike()
    {
        stateMachine.Player.RunCoroutine(SpawnFlamingDragonRoarStrike());
    }

    IEnumerator SpawnFlamingDragonRoarStrike()
    {
        yield return new WaitForSeconds(flamingDragonRoarStrikeData.WaitingTImeSpawnVFX);
        InstantiateProjectile();
    }

    private void InstantiateProjectile()
    {
        GameObject magmaStrike = Object.Instantiate(flamingDragonRoarStrikeData.Effect_FlameDestroyer, firePoint.position, firePoint.rotation);
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
