using HutongGames.PlayMaker.Actions;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerLightAttackState : PlayerCombatState
{
    private PlayerLightAttackData lightAttackData;

    public Vector3 destination;

    public Transform firePoint;

    public Coroutine SkillCoroutine;

    //public GameObject LightAttack_Projectile;



    public PlayerLightAttackState(PlayerMovementStateMachine playerMovementStateMachine) : base(playerMovementStateMachine)
    {
        lightAttackData = movementData.LightAttackData;
    }


    #region IState Methods
    public override void Enter()
    {
        stateMachine.ReusableData.MovementSpeedModifier = 0f;

        stateMachine.Player.Rigidbody.velocity = Vector3.zero;

        base.Enter();

        StartAnimation(stateMachine.Player.AnimationData.LightAttackParameterHash);

        firePoint = stateMachine.Player.transform.Find("FirePoint");
        firePoint.transform.rotation = stateMachine.Player.transform.rotation;

        ShootProjectile();
    }

    public override void Exit()
    {
        base.Exit();

        StopAnimation(stateMachine.Player.AnimationData.LightAttackParameterHash);
    }

    public override void Update()
    {
        base.Update();

        //ShootProjectile();
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
    private void ShootProjectile()
    {
        Ray ray = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            lightAttackData.Destination = hit.point;
        }
        else
        {
            lightAttackData.Destination = ray.GetPoint(1000);
        }

        //InstantiateProjectile();
        //StartCoroutine(SpawnVFX());
        stateMachine.Player.RunCoroutine(SpawnVFX());
    }

    IEnumerator SpawnVFX()
    {
        yield return new WaitForSeconds(lightAttackData.WaitingTImeSpawnVFX);
        InstantiateProjectile();
    }

    private void InstantiateProjectile()
    {
        var projecttileObj = Object.Instantiate(lightAttackData.VFX_LightAttack_Projectile, firePoint.position, firePoint.rotation);
        projecttileObj.GetComponent<Rigidbody>().velocity = ( stateMachine.Player.transform.forward).normalized * lightAttackData.ProjectileSpeed;
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
    protected override void OnLightAttackStarted(InputAction.CallbackContext context)
    {
        
    }
    #endregion
}
