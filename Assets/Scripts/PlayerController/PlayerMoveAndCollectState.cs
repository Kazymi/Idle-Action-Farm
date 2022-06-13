public class PlayerMoveAndCollectState : PlayerMoveState
{
    private readonly PlayerInstrumentActivator _playerInstrumentActivator;

    public PlayerMoveAndCollectState(PlayerAnimatorController playerAnimatorController,
        IMovementDirection movementDirection, PlayerMovementConfiguration playerMovementConfiguration,
        PlayerStateMachine playerMovement, PlayerInstrumentActivator playerInstrumentActivator) : base(
        playerAnimatorController, movementDirection, playerMovementConfiguration, playerMovement)
    {
        _playerInstrumentActivator = playerInstrumentActivator;
    }

    public override void OnStateEnter()
    {
        _playerAnimatorController.SetBool(PlayerAnimationType.WalkAndCollecting, true);
        _playerInstrumentActivator.SetInstrumentActivation(InstrumentType.Braid, true);
    }

    public override void OnStateExit()
    {
        _playerAnimatorController.SetBool(PlayerAnimationType.WalkAndCollecting, false);
        _playerInstrumentActivator.SetInstrumentActivation(InstrumentType.Braid, false);
    }
}