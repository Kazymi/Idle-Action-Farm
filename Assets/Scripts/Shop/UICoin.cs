using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class UICoin : MonoPooled
{
    [SerializeField] private UICoinConfiguration uiCoinConfiguration;

    public void Initialize(Vector3 startPos, Vector3 endPos)
    {
        var sequence = DOTween.Sequence();
        transform.position = startPos;
        sequence.Append(transform.DOLocalMove(endPos, uiCoinConfiguration.Duration));
        sequence.onComplete += ReturnToPool;
    }
}