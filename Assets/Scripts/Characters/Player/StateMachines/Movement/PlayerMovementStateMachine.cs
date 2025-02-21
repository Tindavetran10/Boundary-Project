using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementStateMachine : StateMachine
{
    public Player Player { get; }

    public PlayerStateReusableData ReusableData { get; }

    public PlayerIdlingState IdlingState { get;  }

    public PlayerDashingState DashingState { get;  }

    public PlayerWalkingState WalkingState { get; }

    public PlayerRunningState RunningState { get; }

    public PlayerSprintingState SprintingState { get; }

    public PlayerLightStoppingState LightStoppingState { get; }

    public PlayerMediumStoppingState MediumStoppingState { get; }
    
    public PLayerHardStoppingState HardStoppingState { get; }

    public PlayerLightLandingState LightLandingState { get; }

    public PlayerRollingState RollingState { get; }

    public PlayerHardLandingState HardLandingState { get; }

    public PlayerJumpingState JumpingState { get; }

    public PlayerFailingState FailingState { get; }

    public PlayerLightAttackState LightAttackState { get; }

    public PlayerSkill1State Skill1State { get; }

    public PlayerElectroNovaState ElectroNovaState { get; }

    public PlayerCelestialTempestState CelestialTempestState { get; }

    public PlayerFlamingDragonRoarStrikeState FlamingDragonRoarStrikeState { get; }


    public PlayerMovementStateMachine(Player player)
    {
        Player = player;
        ReusableData = new PlayerStateReusableData();

        IdlingState = new PlayerIdlingState(this);
        DashingState = new PlayerDashingState(this);

        WalkingState = new PlayerWalkingState(this);
        RunningState = new PlayerRunningState(this);
        SprintingState = new PlayerSprintingState(this);

        LightStoppingState = new PlayerLightStoppingState(this);
        MediumStoppingState = new PlayerMediumStoppingState(this);
        HardStoppingState = new PLayerHardStoppingState(this);

        LightLandingState = new PlayerLightLandingState(this);
        RollingState = new PlayerRollingState(this);
        HardLandingState = new PlayerHardLandingState(this);

        JumpingState = new PlayerJumpingState(this);
        FailingState = new PlayerFailingState(this);

        LightAttackState = new PlayerLightAttackState(this);
        Skill1State = new PlayerSkill1State(this);
        ElectroNovaState = new PlayerElectroNovaState(this);
        CelestialTempestState = new PlayerCelestialTempestState(this);
        FlamingDragonRoarStrikeState = new PlayerFlamingDragonRoarStrikeState(this);
    }
}
