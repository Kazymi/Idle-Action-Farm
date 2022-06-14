using System;
using System.Collections;
using DG.Tweening;
using UnityEngine;

public class DroppedCorn : MonoPooled,ISalableItem
{
    [SerializeField] private DroppedCornConfiguration droppedCornConfiguration;

    private Shop _currentShop;
    
    public bool IsAttached { get; private set; }
    public override void Initialize()
    {
        base.Initialize();
        IsAttached = false;
    }

    public void MoveAndAttach(Transform position,float height)
    {
        IsAttached = true;
        transform.parent = position;
        transform.DOLocalMove(new Vector3(0,height,0), droppedCornConfiguration.Duration).SetEase(Ease.InOutBack);
        transform.DOLocalRotate(Vector3.zero, droppedCornConfiguration.Duration);

    }

    public void MoveAndSellYourself(Transform position, Shop shop)
    {
        var sequence = DOTween.Sequence();
        transform.parent = position;
        sequence.Append(transform.DOLocalMove(new Vector3(0,0,0), droppedCornConfiguration.Duration).SetEase(Ease.InOutBack));
        sequence.Join(transform.DOLocalRotate(Vector3.zero, droppedCornConfiguration.Duration));
        _currentShop = shop;
        sequence.onComplete += ToShop;
    }

    private void ToShop()
    {
        _currentShop.Sell(droppedCornConfiguration.PriceConfiguration);
        ReturnToPool();
    }
}