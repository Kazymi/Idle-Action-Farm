using System.Collections;
using StateMachine;
using StateMachine.Conditions;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private PlayerMovementConfiguration playerMovementConfiguration;
    [SerializeField] private Animator animator;

    private CharacterController _characterController;
    public Vector3 Position => transform.position;
    public Quaternion Rotation => transform.rotation;

    private PlayerAnimatorController _playerAnimatorController;
    private global::StateMachine.StateMachine _stateMachine;

    private void Awake()
    {
        _characterController = GetComponent<CharacterController>();
        _playerAnimatorController = new PlayerAnimatorController(animator);
    }

    private void Start()
    {
        var movementDirection = ServiceLocator.GetService<IMovementDirection>();
        InitializeStateMachine(movementDirection);
    }

    private void Update()
    {
        _stateMachine.Tick();
    }

    private void InitializeStateMachine(IMovementDirection movementDirection)
    {
        var idleState = new PlayerIdleState(_playerAnimatorController);
        var movementState = new PlayerMoveState(_playerAnimatorController, movementDirection,
            playerMovementConfiguration, this);

        idleState.AddTransition(new StateTransition(movementState,
            new FuncCondition(() => movementDirection.Direction != Vector2.zero)));
        movementState.AddTransition(new StateTransition(idleState,
            new FuncCondition(() => movementDirection.Direction == Vector2.zero)));

        _stateMachine = new global::StateMachine.StateMachine(idleState);
    }

    public void Move(Vector3 position)
    {
        var newPosition = new Vector3(position.x, 0, -position.y);
        transform.LookAt(newPosition+transform.position);
        _characterController.Move(newPosition);
    }
}