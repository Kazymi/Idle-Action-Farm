using StateMachine;

public class PlayerIdleCollectionState : State
{
    private readonly PlayerAnimatorController _playerAnimatorController;
    private readonly PlayerInstrumentActivator _playerInstrumentActivator;

    public PlayerIdleCollectionState(PlayerAnimatorController playerAnimatorController,PlayerInstrumentActivator playerInstrumentActivator)
    {
        _playerAnimatorController = playerAnimatorController;
        _playerInstrumentActivator = playerInstrumentActivator;
    }

    public override void OnStateEnter()
    {
        _playerInstrumentActivator.SetInstrumentActivation(InstrumentType.Braid,true);
        _playerAnimatorController.SetBool(PlayerAnimationType.IdleAndCollecting, true);
    }

    public override void OnStateExit()
    {
        _playerInstrumentActivator.SetInstrumentActivation(InstrumentType.Braid,true);
        _playerAnimatorController.SetBool(PlayerAnimationType.IdleAndCollecting, false);
    } 
}