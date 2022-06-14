using UnityEngine;

public class PlayerMoneyUI : MonoBehaviour
{
    [SerializeField] private TextController textController;

    private PlayerParameters _playerParameters;

    private void Start()
    {
        _playerParameters = ServiceLocator.GetService<PlayerParameters>();
        _playerParameters.moneyUpdated += UpdateMoney;
        UpdateMoney();
    }

    private void OnEnable()
    {
        if (_playerParameters == null) return;
        _playerParameters.moneyUpdated += UpdateMoney;
    }

    private void OnDisable()
    {
        _playerParameters.moneyUpdated -= UpdateMoney;
    }

    private void UpdateMoney()
    {
        textController.UpdateText(_playerParameters.CurrentMoney.ToString());
    }
}