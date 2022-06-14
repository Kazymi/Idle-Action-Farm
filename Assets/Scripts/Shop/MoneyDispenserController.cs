using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class MoneyDispenserController : MonoBehaviour
{
    [SerializeField] private MoneyControllerConfiguration moneyControllerConfiguration;
    
    private PlayerParameters _playerParameters;
    private PlayerMoneyUI _playerMoneyUI;
    private int _moneyInDelay;

    private void Start()
    {
        _playerParameters = ServiceLocator.GetService<PlayerParameters>();
        _playerMoneyUI = ServiceLocator.GetService<PlayerMoneyUI>();
    }

    private void OnEnable()
    {
        ServiceLocator.Subscribe<MoneyDispenserController>(this);
    }

    private void OnDisable()
    {
        ServiceLocator.Unsubscribe<MoneyDispenserController>();
    }
    
    private IEnumerator MoneyDispenser()
    {
        _playerMoneyUI.StartShakeShake();
        while (_moneyInDelay > 0)
        {
            _moneyInDelay--;
            _playerParameters.AddMoney(1);
            yield return new WaitForSeconds(moneyControllerConfiguration.AddMoneyInterval);
        }
        _playerMoneyUI.PauseShake();
    }
    
    public void AddMoney(int amount)
    {
        if (_moneyInDelay == 0)
        {
            _moneyInDelay += amount;
            StartCoroutine(MoneyDispenser());
        }
        else
        {
            _moneyInDelay += amount;
        }
    }
}