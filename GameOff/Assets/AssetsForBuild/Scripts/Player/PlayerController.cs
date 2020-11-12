using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(PlayerInputHandler))]
public class PlayerController : MonoBehaviour
{
    [SerializeField] private float m_MoveSpeed;
    [SerializeField] private float m_JumpForce;
    [SerializeField] private float m_JumpBreakForce;
    [SerializeField] private float m_gravityScale;
    [SerializeField] private float m_rotateSpeed;

    [SerializeField] private Transform playerModel;

    private Vector3 _moveDir;

    public bool CanMove { get; private set; }

    private CameraController cam;
    private CharacterController controller;
    private PlayerInputHandler playerInput;
    private PlayerEventTransmitter playerEventTransmitter;
    private RoverController rover;

    [HideInInspector]public UnityEvent e_Jump;

    private void Awake()
    {
        cam = FindObjectOfType<CameraController>();
        controller = this.GetComponent<CharacterController>();
        playerInput = this.GetComponent<PlayerInputHandler>();
        playerEventTransmitter = FindObjectOfType<PlayerEventTransmitter>();
        rover = FindObjectOfType<RoverController>();

        playerEventTransmitter.e_Jump.AddListener(AddJumpForce);
        playerEventTransmitter.e_EnableMovement.AddListener(EnableMovement);
        playerEventTransmitter.e_DisableMovement.AddListener(DisableMovement);
    }

    private void Start()
    {
        Init();
    }

    void Init()
    {
        CanMove = true;
    }

    private void Update()
    {
        Move();
        HandleCarInteractionState();
    }

    void Move()
    {
        if (!CanMove)
        {
            controller.Move(Vector3.zero);
            return;
        }

        //Move the player
        float yStore = _moveDir.y;
        _moveDir = (transform.forward * playerInput.InputVector.y) + (transform.right * playerInput.InputVector.x);
        _moveDir = _moveDir.normalized * m_MoveSpeed;
        _moveDir.y = yStore;

        if (controller.isGrounded)
        {
            if (playerInput.PrepareForJump)
            {
                e_Jump.Invoke();
            }
        }
        else
        {
            if (playerInput.JumpBreak)
            {
                _moveDir.y *= m_JumpBreakForce;
            }
        }

        _moveDir.y = _moveDir.y + (Physics.gravity.y * m_gravityScale * Time.deltaTime);

        controller.Move(_moveDir * Time.deltaTime);

        //Move the player in different directions based on camera look direction
        if (playerInput.InputVector.x != 0 || playerInput.InputVector.y != 0)
        {
            this.transform.rotation = Quaternion.Euler(0f, cam.pivot.rotation.eulerAngles.y, 0f);
            Quaternion newRotation = Quaternion.LookRotation(new Vector3(_moveDir.x, 0, _moveDir.z));
            playerModel.rotation = Quaternion.Slerp(playerModel.rotation, newRotation, m_rotateSpeed * Time.deltaTime);
        }
    }

    void HandleCarInteractionState()
    {
        if (playerInput.InteractWithCar)
        {

            if (rover.IsPlayerNearCar)
            {
                rover.GetInTheCar();
            }

            if (rover.IsPlayerInCar)
            {
                rover.GetOutOfCar();
            }
        }
    }

    void AddJumpForce()
    {
        if (playerInput.Jump)
            _moveDir.y = m_JumpForce;
        else
            _moveDir.y = m_JumpForce * 0.5f;
    }

    void DisableMovement()
    {
        CanMove = false;
    }

    void EnableMovement()
    {
        CanMove = true;
    }
}
