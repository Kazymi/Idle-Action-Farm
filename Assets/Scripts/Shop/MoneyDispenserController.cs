using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class MoneyDispenserController : MonoBehaviour
{
    [SerializeField] private MoneyControllerConfiguration moneyControllerConfiguration;
    [SerializeField] private Transform coinPanel;


    private PlayerParameters _playerParameters;
    private Sequence _sequence;
    private int _moneyInDelay;

    private void Awake()
    {
        SequenceInitialize();
    }

    private void Start()
    {
        _playerParameters = ServiceLocator.GetService<PlayerParameters>();
    }

    private void OnEnable()
    {
        ServiceLocator.Subscribe<MoneyDispenserController>(this);
    }

    private void OnDisable()
    {
        ServiceLocator.Unsubscribe<MoneyDispenserController>();
    }

    private void SequenceInitialize()
    {
        _sequence = DOTween.Sequence();
        _sequence.SetLoops(-1);
         _sequence.Append(coinPanel.DOShakePosition(moneyControllerConfiguration.PanelShakeDuration,
             moneyControllerConfiguration.PanelShakeStrange));
        _sequence.Pause();

    }
    private IEnumerator MoneyDispenser()
    {
        _sequence.Restart();
        while (_moneyInDelay > 0)
        {
            _moneyInDelay--;
            _playerParameters.AddMoney(1);
            yield return new WaitForSeconds(moneyControllerConfiguration.AddMoneyInterval);
        }

        _sequence.Restart();
        _sequence.Pause();
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