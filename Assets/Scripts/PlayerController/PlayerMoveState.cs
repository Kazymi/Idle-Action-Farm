using StateMachine;
using UnityEngine;

public class PlayerMoveState : State
{
    private readonly PlayerAnimatorController _playerAnimatorController;
    private readonly IMovementDirection _movementDirection;
    private readonly PlayerMovementConfiguration _playerMovementConfiguration;
    private readonly PlayerMovement _playerMovement;

    public PlayerMoveState(PlayerAnimatorController playerAnimatorController, IMovementDirection movementDirection,
        PlayerMovementConfiguration playerMovementConfiguration, PlayerMovement playerMovement)
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