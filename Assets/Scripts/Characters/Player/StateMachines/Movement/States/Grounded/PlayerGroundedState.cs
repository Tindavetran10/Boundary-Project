using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerGroundedState : PlayerMovementState
{
    private SlopeData slopeData;
    public PlayerGroundedState(PlayerMovementStateMachine playerMovementStateMachine) : base(playerMovementStateMachine)
    {
        slopeData = stateMachine.Player.ColliderUtility.SlopeData;
    }

    #region IState Methods
    public override void Enter()
    {
        base.Enter();

        StartAnimation(stateMachine.Player.AnimationData.GroundedParameterHash);

        UpdateShouldSprintState();

        UpdateCameraRecenteringState(stateMachine.ReusableData.MovementInput);
    }

    public override void Exit()
    {
        base.Exit();

        StopAnimation(stateMachine.Player.AnimationData.GroundedParameterHash);
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();

        Float();
    }


    #endregion


    #region Main Methods
    private void UpdateShouldSprintState()
    {
        if (!stateMachine.ReusableData.ShouldSprint)
        {
            return;
        }

        if (stateMachine.ReusableData.MovementInput != Vector2.zero)
        {
            return;
        }

        stateMachine.ReusableData.ShouldSprint = false;
    }

    private void Float()
    {
        Vector3 capsuleColliderCenterInWorldSpace = stateMachine.Player.ColliderUtility.CapsuleColliderData.Collider.bounds.center;
        Ray downwardsRayFromCapsuleCenter = new Ray(capsuleColliderCenterInWorldSpace, Vector3.down);

        if (Physics.Raycast(downwardsRayFromCapsuleCenter, out RaycastHit hit, slopeData.FloatRayDistance, stateMachine.Player.LayerData.GroundLayer, QueryTriggerInteraction.Ignore))
        {
            float groundAngle = Vector3.Angle(hit.normal, -downwardsRayFromCapsuleCenter.direction);

            float slopeSpeedModifier = SetSlopeSpeedModifierOnAngle(groundAngle);

            if (slopeSpeedModifier == 0f)
            {
                return;
            }

            float distanceToFloatingPoint = stateMachine.Player.ColliderUtility.CapsuleColliderData.ColliderCenterInLocalSpace.y * stateMachine.Player.transform.localScale.y - hit.distance;
            
            if(distanceToFloatingPoint == 0f)
            {
                return;
            }

            float amountToLift = distanceToFloatingPoint * slopeData.StepReachForce - GetPlayerVerticalVelocity().y;

            Vector3 liftForce = new Vector3(0f, amountToLift, 0f);

            stateMachine.Player.Rigidbody.AddForce(liftForce, ForceMode.VelocityChange);
        }
    }

    private float SetSlopeSpeedModifierOnAngle(float angle)
    {
        float slopeSpeedModifier = movementData.SlopeSpeedAngles.Evaluate(angle);

        if (stateMachine.ReusableData.MovementOnSlopesSpeedModifier != slopeSpeedModifier)
        {
            stateMachine.ReusableData.MovementOnSlopesSpeedModifier = slopeSpeedModifier;

            UpdateCameraRecenteringState(stateMachine.ReusableData.MovementInput);
        }

        return slopeSpeedModifier;
    }
    private bool IsThereGroundUnderneath()
    {
        BoxCollider groundCheckCollider = stateMachine.Player.ColliderUtility.TriggerColliderData.GroundCheckCollider;

        Vector3 groundColliderCenterInWorldSpace = groundCheckCollider.bounds.center;

        Collider[] overlappedGroundColliders = Physics.OverlapBox(groundColliderCenterInWorldSpace, stateMachine.Player.ColliderUtility.TriggerColliderData.GroundCheckColliderExtends, groundCheckCollider.transform.rotation, stateMachine.Player.LayerData.GroundLayer, QueryTriggerInteraction.Ignore);

        return overlappedGroundColliders.Length > 0;
    }
    #endregion

    #region Reusable Methods
    protected override void AddInputActionsCallBack()
    {
        base.AddInputActionsCallBack();

        stateMachine.Player.Input.PlayerActions.Dash.started += OnDashStarted;

        stateMachine.Player.Input.PlayerActions.Jump.started += OnJumpStarted;

        stateMachine.Player.Input.PlayerActions.LightAttack.started += OnLightAttackStarted;

        stateMachine.Player.Input.PlayerActions.Skill1.started += OnSkill1State;

        stateMachine.Player.Input.PlayerActions.Skill2.started += OnElectroNovaState;

        stateMachine.Player.Input.PlayerActions.Skill3.started += OnCelestialTempestState;

        stateMachine.Player.Input.PlayerActions.Skill4.started += OnFlamingDragonRoarStrikeState;
    }

    protected override void RemoveInputActionsCallBack()
    {
        base.RemoveInputActionsCallBack();

        stateMachine.Player.Input.PlayerActions.Dash.started -= OnDashStarted;
    
        stateMachine.Player.Input.PlayerActions.Jump.started -= OnJumpStarted;

        stateMachine.Player.Input.PlayerActions.LightAttack.started -= OnLightAttackStarted;

        stateMachine.Player.Input.PlayerActions.Skill1.started -= OnSkill1State;

        stateMachine.Player.Input.PlayerActions.Skill2.started -= OnElectroNovaState;

        stateMachine.Player.Input.PlayerActions.Skill3.started -= OnCelestialTempestState;

        stateMachine.Player.Input.PlayerActions.Skill4.started -= OnFlamingDragonRoarStrikeState;
    }
    protected virtual void OnMove()
    {
        if (stateMachine.ReusableData.ShouldSprint)
        {
            stateMachine.ChangeState(stateMachine.SprintingState);

            return;
        }

        if (stateMachine.ReusableData.ShouldWalk)
        {
            stateMachine.ChangeState(stateMachine.WalkingState);
            return;
        }

        stateMachine.ChangeState(stateMachine.RunningState);
    }

    protected override void OnContactWithGroundExited(Collider collider)
    {
        base.OnContactWithGroundExited(collider);

        if (IsThereGroundUnderneath())
        {
            return;
        }

        Vector3 capsuleColliderCenterInWorldSpace = stateMachine.Player.ColliderUtility.CapsuleColliderData.Collider.bounds.center;

        Ray downwardsRayFromCapsuleBottom = new Ray(capsuleColliderCenterInWorldSpace - stateMachine.Player.ColliderUtility.CapsuleColliderData.ColliderVerticalExtents, Vector3.down);

        if (!Physics.Raycast(downwardsRayFromCapsuleBottom, out _, movementData.GroundToFallRayDistance, stateMachine.Player.LayerData.GroundLayer, QueryTriggerInteraction.Ignore))
        {
            OnFall();
        }
    }

    protected virtual void OnFall()
    {
        stateMachine.ChangeState(stateMachine.FailingState);
    }
    #endregion


    #region Input Method
    protected virtual void OnDashStarted(InputAction.CallbackContext context)
    {
        stateMachine.ChangeState(stateMachine.DashingState);
    }

    protected virtual void OnJumpStarted(InputAction.CallbackContext context)
    {
        stateMachine.ChangeState(stateMachine.JumpingState);
    }

    protected virtual void OnLightAttackStarted(InputAction.CallbackContext context)
    {
        stateMachine.ChangeState(stateMachine.LightAttackState);
    }

    protected virtual void OnSkill1State(InputAction.CallbackContext context)
    {
        stateMachine.ChangeState(stateMachine.Skill1State);
    }

    protected virtual void OnElectroNovaState(InputAction.CallbackContext context)
    {
        stateMachine.ChangeState(stateMachine.ElectroNovaState);
    }

    protected virtual void OnCelestialTempestState(InputAction.CallbackContext context)
    {
        stateMachine.ChangeState(stateMachine.CelestialTempestState);
    }

    protected virtual void OnFlamingDragonRoarStrikeState(InputAction.CallbackContext context)
    {
        stateMachine.ChangeState(stateMachine.FlamingDragonRoarStrikeState);
    }
    #endregion
}
