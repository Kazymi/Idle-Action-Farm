using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class BalanceController : MonoBehaviour
{
    [SerializeField] private Transform rotateObject;
    [SerializeField] private BalanceConfiguration balanceConfiguration;

    private IMovementDirection _movementDirection;
    private float _currentShaking;
    private Sequence _rotateSequence;

    private void Start()
    {
        _movementDirection = ServiceLocator.GetService<IMovementDirection>();
        RotateSequenceInitialize();
    }

    private void Update()
    {
        RecalculateShaking();
    }

    private void RecalculateShaking()
    {
        if (_movementDirection.Direction == Vector2.zero && _currentShaking == balanceConfiguration.IdleShaking)
        {
            return;
        }

        if (_movementDirection.Direction != Vector2.zero)
        {
            _currentShaking += balanceConfiguration.ShakingIncrease * Time.deltaTime;
            if (_currentShaking > balanceConfiguration.MAXShaking)
            {
                _currentShaking = balanceConfiguration.MAXShaking;
            }
        }
        else
        {
            _currentShaking -= balanceConfiguration.ShakingIncrease * Time.deltaTime;
            if (_currentShaking < balanceConfiguration.IdleShaking)
            {
                _currentShaking = balanceConfiguration.IdleShaking;
            }
        }
    }

    private void RotateSequenceInitialize()
    {
        _rotateSequence = DOTween.Sequence();
        _rotateSequence.Append(rotateObject.DOLocalRotate(new Vector3(0, 0, _currentShaking),
            balanceConfiguration.Speed, RotateMode.LocalAxisAdd));
        _rotateSequence.Append(rotateObject.DOLocalRotate(new Vector3(0, 0, -_currentShaking),
            balanceConfiguration.Speed, RotateMode.LocalAxisAdd));
        _rotateSequence.onComplete += RotateSequenceInitialize;
    }
}