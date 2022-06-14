using System;
using System.Collections;
using DG.Tweening;
using UnityEngine;

public class DroppedCorn : MonoPooled
{
    [SerializeField] private DroppedCornConfiguration droppedCornConfiguration;

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
        transform.DOLocalMove(new Vector3(0,height,0), droppedCornConfiguration.Duration).SetEase(Ease.OutFlash);
        transform.DOLocalRotate(Vector3.zero, droppedCornConfiguration.Duration);

    }
}