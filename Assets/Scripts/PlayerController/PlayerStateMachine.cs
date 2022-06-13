using System.Collections;
using StateMachine;
using StateMachine.Conditions;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerStateMachine : MonoBehaviour
{
    [SerializeField] private PlayerMovementConfiguration playerMovementConfiguration;
    [SerializeField] private Animator animator;
    [SerializeField] private Harvester harvester;

    private CharacterController _characterController;

    private PlayerAnimatorController _playerAnimatorController;
    private global::StateMachine.StateMachine _stateMachine;

    private void Awake()
    {
        _characterController = GetComponent<CharacterController>();
        _playerAnimatorController = new PlayerAnimatorController(animator);
    }

    private void Start()
    {
        var playerInstrumentActivator = ServiceLocator.GetService<PlayerInstrumentActivator>();
        var movementDirection = ServiceLocator.GetService<IMovementDirection>();
        InitializeStateMachine(movementDirection, playerInstrumentActivator);
    }

    private void Update()
    {
        _stateMachine.Tick();
    }

    private void InitializeStateMachine(IMovementDirection movementDirection,
        PlayerInstrumentActivator playerInstrumentActivator)
    {
        var idleState = new PlayerIdleState(_playerAnimatorController);
        var movementState = new PlayerMoveState(_playerAnimatorController, movementDirection,
            playerMovementConfiguration, this);
        var movementAndCollectionState = new PlayerMoveAndCollectState(_playerAnimatorController, movementDirection,
            playerMovementConfiguration, this, playerInstrumentActivator);
        var idleCollectionState = new PlayerIdleCollectionState(_playerAnimatorController, playerInstrumentActivator);

        idleState.AddTransition(new StateTransition(movementState,
            new FuncCondition(() => movementDirection.Direction != Vector2.zero)));
        idleState.AddTransition(new StateTransition(idleCollectionState,
            new FuncCondition(() => harvester.CurrentCorn != null && movementDirection.Direction == Vector2.zero)));

        movementState.AddTransition(new StateTransition(idleState,
            new FuncCondition(() => movementDirection.Direction == Vector2.zero)));
        movementState.AddTransition(new StateTransition(movementAndCollectionState,
            new FuncCondition(() => harvester.CurrentCorn != null)));

        movementAndCollectionState.AddTransition(new StateTransition(movementState,
            new FuncCondition(() => harvester.CurrentCorn == null && movementDirection.Direction != Vector2.zero)));
        movementAndCollectionState.AddTransition(new StateTransition(idleState,
            new FuncCondition(() => harvester.CurrentCorn == null && movementDirection.Direction == Vector2.zero)));
        movementAndCollectionState.AddTransition(new StateTransition(idleState,
            new FuncCondition(() => harvester.CurrentCorn != null && movementDirection.Direction == Vector2.zero)));

        idleCollectionState.AddTransition(new StateTransition(idleState,
            new FuncCondition(() => harvester.CurrentCorn == null && movementDirection.Direction == Vector2.zero)));
        idleCollectionState.AddTransition(new StateTransition(movementState,
            new FuncCondition(() => harvester.CurrentCorn == null && movementDirection.Direction != Vector2.zero)));   
        idleCollectionState.AddTransition(new StateTransition(movementAndCollectionState,
            new FuncCondition(() => harvester.CurrentCorn != null && movementDirection.Direction != Vector2.zero)));
        _stateMachine = new global::StateMachine.StateMachine(idleState);
    }

    public void Move(Vector3 position)
    {
        var newPosition = new Vector3(position.x, 0, -position.y);
        transform.LookAt(newPosition + transform.position);
        _characterController.Move(newPosition);
    }
}