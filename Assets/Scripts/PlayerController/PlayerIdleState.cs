using StateMachine;

public class PlayerIdleState : State
{
    private readonly PlayerAnimatorController _playerAnimatorController;

    public PlayerIdleState(PlayerAnimatorController playerAnimatorController)
    {
        _playerAnimatorController = playerAnimatorController;
    }

    public override void OnStateEnter()
    {
        _playerAnimatorController.SetBool(PlayerAnimationType.Idle, true);
    }

    public override void OnStateExit()
    {
        _playerAnimatorController.SetBool(PlayerAnimationType.Idle, false);
    }
}