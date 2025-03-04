using System.Collections;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(PlayerInputs))]

public class Player : MonoBehaviour
{
    public static Player PlayerInstance { get; private set; }

    [field: Header("Reference")]
    [field: SerializeField] public PlayerSO Data { get; private set; }

    [field: Header("Collisions")]
    [field: SerializeField] public PlayerCapsuleColliderUtility ColliderUtility { get; private set; }
    [field: SerializeField] public PlayerLayerData LayerData { get; private set; }

    [field: Header("Cameras")]
    [field: SerializeField] public PlayerCameraUtility CameraUtility { get; private set; }

    [field: Header("Animations")]
    [field: SerializeField] public PlayerAnimationData AnimationData { get; private set; }

    public PlayerInputs Input { get; private set; }

    public Rigidbody Rigidbody { get; private set; }

    public Animator Animator { get; private set; }

    public Transform MainCameraTransform { get; private set; }

    private PlayerMovementStateMachine movementStateMachine;

    private PlayerMovementState movementSate;

    [field: Header("UIManager")]
    public Image lightAttackImg;
    public Image magmaStrikeImg;
    public Image electroNovaImg;
    public Image celestialTempestImg;
    public Image flamingDragonRoarStrikeImg;

    public MainMenu mainMenu;

    [SerializeField] PlayerManaBar manaBar;

    private void Awake()
    {
        if (PlayerInstance != null && PlayerInstance != this)
        {
            Destroy(PlayerInstance);
        }
        else
        {
            PlayerInstance = this;
        }

        Rigidbody = GetComponent<Rigidbody>();
        Animator = GetComponentInChildren<Animator>();
        Input = GetComponent<PlayerInputs>();

        ColliderUtility.Initialize(gameObject);
        ColliderUtility.CalculateCapsuleColliderDimensions();
        CameraUtility.Initialize();
        AnimationData.Initialize();

        MainCameraTransform = Camera.main.transform;

        movementStateMachine = new PlayerMovementStateMachine(this);
    }

    private void OnValidate()
    {
        ColliderUtility.Initialize(gameObject);
        ColliderUtility.CalculateCapsuleColliderDimensions();
    }

    // Start is called before the first frame update
    private void Start()
    {
        movementStateMachine.ChangeState(movementStateMachine.IdlingState);
    }

    private void OnTriggerEnter(Collider collider)
    {
        movementStateMachine.OnTriggerEnter(collider);
    }

    private void OnTriggerExit(Collider collider)
    {
        movementStateMachine.OnTriggerExit(collider);
    }

    // Update is called once per frame
    private void Update()
    {
        movementStateMachine.HandleInput();

        movementStateMachine.Update();

        PauseGame();

        GameManager.Instance._playerMana.ManaUnit();
        manaBar.SetMana(GameManager.Instance._playerMana.Mana);
        GameManager.Instance._playerHealth.HealUnit();
        Debug.Log(GameManager.Instance._playerMana.Mana);
    }
     
    private void FixedUpdate()
    {
        movementStateMachine.PhysicsUpdate();
    }

    public void OnMovementStateAnimationEnterEvent()
    {
        movementStateMachine.OnAnimationEnterEvent();
    }

    public void OnMovementStateAnimationExitEvent()
    {
        movementStateMachine.OnAnimationExitEvent();
    }

    public void OnMovementStateAnimationTransitionEvent()
    {
        movementStateMachine.OnAnimationTransitionEvent();
    }

    public Coroutine RunCoroutine(IEnumerator coroutine)
    {
        return StartCoroutine(coroutine);
    }

    public void DestroyEffect(GameObject gameObject, float effectDuration)
    {
        Destroy(gameObject, effectDuration);
    }

    public void PauseGame()
    {
        if (mainMenu == null)
        {
            Debug.Log("Khong thay Main Menu");
        }

        if (Input.PlayerActions.Pause.WasPressedThisFrame())
        {
            Debug.Log(Input.PlayerActions.Pause.WasPressedThisFrame());
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            mainMenu.PauseTheGame();
            Debug.Log("Trang thai tro chuot: " + Cursor.visible);
        }
    }
}
