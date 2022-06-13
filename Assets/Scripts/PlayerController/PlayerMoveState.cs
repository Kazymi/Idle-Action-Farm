using StateMachine;
using UnityEngine;

public class PlayerMoveState : State
{
    protected readonly PlayerAnimatorController _playerAnimatorController;
    private readonly IMovementDirection _movementDirection;
    private readonly PlayerMovementConfiguration _playerMovementConfiguration;
    private readonly PlayerStateMachine _playerMovement;

    public PlayerMoveState(PlayerAnimatorController playerAnimatorController, IMovementDirection movementDirection,
        PlayerMovementConfiguration playerMovementConfiguration, PlayerStateMachine playerMovement)
    {
        _playerAnimatorController = playerAnimatorController;
        _movementDirection = movementDirection;
        _playerMovementConfiguration = playerMovementConfiguration;
        _playerMovement = playerMovement;
    }

    public override void OnStateEnter()
    {
        _playerAnimatorController.SetBool(PlayerAnimationType.Walk, true);
    }

    public override void OnStateExit()
    {
        _playerAnimatorController.SetBool(PlayerAnimationType.Walk, false);
    }

    public override void Tick()
    {
        Move();
    }

    private void Move()
    {
        var newPosition = _movementDirection.Direction * Time.deltaTime * _playerMovementConfiguration.Speed;
        _playerMovement.Move(newPosition);
    }
}