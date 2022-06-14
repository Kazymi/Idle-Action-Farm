using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class UICoin : MonoPooled
{
    [SerializeField] private UICoinConfiguration uiCoinConfiguration;

    private PlayerMoneyUI _playerMoneyUI;
    public void Initialize(Vector3 startPos, Vector3 endPos)
    {
        if(_playerMoneyUI == null)  _playerMoneyUI = ServiceLocator.GetService<PlayerMoneyUI>();
        var sequence = DOTween.Sequence();
        transform.position = startPos;
        sequence.Append(transform.DOLocalMove(endPos, uiCoinConfiguration.Duration).SetEase(Ease.InOutBack));
        sequence.onComplete += Finish;
    }

    private void Finish()
    {
        _playerMoneyUI.PlayImageShake();
        ReturnToPool();
    }
}