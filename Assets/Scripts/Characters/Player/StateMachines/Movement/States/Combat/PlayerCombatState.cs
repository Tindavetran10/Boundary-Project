using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombatState : PlayerGroundedState
{
    public PlayerCombatState(PlayerMovementStateMachine playerMovementStateMachine) : base(playerMovementStateMachine)
    {
    }

    public override void Enter()
    {
        base.Enter();

        StartAnimation(stateMachine.Player.AnimationData.AttackParameterHash);
    }

    public override void Exit()
    {
        base.Exit();

        StopAnimation(stateMachine.Player.AnimationData.AttackParameterHash);
    }
}
