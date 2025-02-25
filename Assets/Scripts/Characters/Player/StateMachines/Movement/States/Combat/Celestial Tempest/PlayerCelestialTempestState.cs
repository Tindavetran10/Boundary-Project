using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerCelestialTempestState : PlayerCombatState
{
    public PlayerCelestialTempestData celestialTempestData;

    public Transform startPoint;

    public float effectDuration = 6f;

    public PlayerCelestialTempestState(PlayerMovementStateMachine playerMovementStateMachine) : base(playerMovementStateMachine)
    {
        celestialTempestData = movementData.CelestialTempestData;
    }

    #region IState Methods
    public override void Enter()
    {
        stateMachine.ReusableData.MovementSpeedModifier = 0f;

        stateMachine.Player.Rigidbody.velocity = Vector3.zero;

        base.Enter();

        StartAnimation(stateMachine.Player.AnimationData.CelestialTempestAttackParameterHash);

        startPoint = stateMachine.Player.transform;
        startPoint.transform.rotation = stateMachine.Player.transform.rotation;

        CelestialTempest();
    }

    public override void Exit()
    {
        base.Exit();

        StopAnimation(stateMachine.Player.AnimationData.CelestialTempestAttackParameterHash);
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
    private void CelestialTempest()
    {
        stateMachine.Player.RunCoroutine(SpawnCelestialTempest());
    }

    IEnumerator SpawnCelestialTempest()
    {
        yield return new WaitForSeconds(celestialTempestData.WaitingTImeSpawnVFX);
        InstantiateProjectile();
    }

    private void InstantiateProjectile()
    {
        GameObject magmaStrike = Object.Instantiate(celestialTempestData.Effect_PowerOfLightning, startPoint.position, startPoint.rotation);
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
