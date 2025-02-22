using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Serialization;

public partial class EnemyStateMachine : MonoBehaviour
{
    [Header("State machine")]
    [SerializeField] private EnemyState currentState;
    public EnemySpawner spawner;
    [SerializeField] EnemyInfomation enemyInfomation;
    [SerializeField] EnemyBehaviourTree enemyBehaviour;
    public Animator animator;
    [SerializeField] private NavMeshAgent agent;
    [Header("Time")]
    [SerializeField] float timerIdle;
    [SerializeField] float timerPatrol;
    [SerializeField] float timeChangePatrol;
    [SerializeField] private float patrollingTime;
    [Header("Patrolling")]
    [SerializeField] bool havePatrolPoint;
    [SerializeField] Vector3 patrolPoint;
    [SerializeField] Vector3 enemyDirection;
    [SerializeField] Vector3 spawnPoint;
    [FormerlySerializedAs("maxDistance")]
    [SerializeField] float chasingDistance;
    [Header("Attack")]
    public bool isDead;

    private void Start()
    {
        currentState = EnemyState.Idle;
        spawnPoint = transform.position;
    }

    private void FixedUpdate()
    {
        if (isDead)
        {
            ChangeState(EnemyState.Dead);
        }
        StateController();
    }

    public void DestroyEnemy()
    {
        spawner.RemoveEnemySpawned(this);
        Destroy(gameObject);
    }

    private void ResetTimer()
    {
        timerIdle = 0;
        timerPatrol = 0;
    }

    private bool ShouldChangeState(float timer, float timeChange)
    {
        return timer >= timeChange;
    }

    private void LoadAnim(string name, float value)
    {
        animator.SetFloat(name, value);
    }

    private void LoadAnim(string name, bool value)
    {
        animator.SetBool(name, value);
    }

    // kiểm tra khoảng cách với mục tiêu
    private float CheckDistanceToTarget(Vector3 target)
    {
        return Vector3.Distance(target, transform.position);
    }

    // kiểm tra player vào vùng nào (warning, chase, atk,...)
    private bool PlayerEnterArea(float area)
    {
        return CheckDistanceToTarget(spawner.playerPosition.position) <= area;
    }

    // xoay enemy về hướng player
    private void RotateToTarget(Vector3 target)
    {
        //tính toán hướng
        enemyDirection = target - transform.position;
        // xoay enemy
        Quaternion rotation = Quaternion.LookRotation(enemyDirection);
        // Giữ nguyên góc xoay trên trục x nếu không phải đơn vị bay
        if (!enemyInfomation.FlyingUnit)
        {
            rotation = Quaternion.Euler(0, rotation.eulerAngles.y, rotation.eulerAngles.z);
        }
        //Thực hiện xoay dần dần để tạo cảm giác mượt mà
        transform.rotation = Quaternion.Lerp(transform.rotation, rotation, Time.deltaTime * 5f);
    }

    private void MoveToTarget(float speed, Vector3 target)
    {
        agent.speed = speed;
        Vector3 targetPosition = target; // Vị trí hợp lệ trên NavMesh
        //Debug.Log("enemyInfomation.FlyingUnit " + enemyInfomation.FlyingUnit);
        if (!enemyInfomation.FlyingUnit)
        {
            targetPosition.y = transform.position.y; // Giữ nguyên y nếu không phải là đơn vị bay
        }
        agent.SetDestination(targetPosition); // Đặt mục tiêu
    }

    private void StateController()
    {
        switch (currentState)
        {
            case EnemyState.Idle:
                IdleState();
                break;
            case EnemyState.Warning:
                WarningState();
                break;
            case EnemyState.BackSpawnPoint:
                BackSpawnPointState();
                break;
            case EnemyState.Patrol:
                PatrolState();
                break;
            case EnemyState.Chase:
                ChaseState();
                break;
            case EnemyState.Attack:
                AttackState();
                break;
            case EnemyState.Retreat:
                RetreatState();
                break;
            case EnemyState.Dead:
                DeadState();
                break;
        }
    }
    public void ChangeState(EnemyState stateChanged)
    {
        currentState = stateChanged;
    }
}

public enum EnemyState
{
    Idle,
    Patrol,
    Warning,
    BackSpawnPoint,
    Chase,
    Attack,
    Retreat,
    Dead
}