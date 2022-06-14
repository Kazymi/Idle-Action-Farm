using System;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    [SerializeField] private Transform sellPosition;
    [SerializeField] private ShopConfiguration shopConfiguration;
    private readonly List<IKeeperOfSalableItems> _keepers = new List<IKeeperOfSalableItems>();
    private float _coolDown;
    private MoneyDispenserController _moneyController;
    private UICoinSpawner _uiCoinSpawner;

    private void Start()
    {
        _uiCoinSpawner = ServiceLocator.GetService<UICoinSpawner>();
        _moneyController = ServiceLocator.GetService<MoneyDispenserController>();
    }

    private void Update()
    {
        RecalculateTimer();
    }

    private void RecalculateTimer()
    {
        if (_keepers.Count == 0)
        {
            return;
        }

        if (_coolDown < 0)
        {
            _coolDown = shopConfiguration.IntervalRequest;
            TryToBuy();
        }
        else
        {
            _coolDown -= Time.deltaTime;
        }
    }

    public void Sell(PriceConfiguration priceConfiguration)
    {
        _moneyController.AddMoney(priceConfiguration.Price);
        _uiCoinSpawner.SpawnCoin();
        
    }

    private void TryToBuy()
    {
        if (_keepers.Count == 0) return;
        foreach (var keeper in _keepers)
        {
            if (keeper.IsItemCanBeSold == false) continue;
            var salableItem = keeper.GetSalableItem();
            salableItem.MoveAndSellYourself(sellPosition, this);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        var keeper = other.GetComponent<IKeeperOfSalableItems>();
        if (keeper == null)
        {
            return;
        }

        _keepers.Add(keeper);
    }

    private void OnTriggerExit(Collider other)
    {
        var keeper = other.GetComponent<IKeeperOfSalableItems>();
        if (keeper == null)
        {
            return;
        }

        _keepers.Remove(keeper);
    }
}