using System;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimatorController
{
    private readonly Animator _animator;
    private readonly Dictionary<PlayerAnimationType, int> _animationHash = new Dictionary<PlayerAnimationType, int>();

    public PlayerAnimatorController(Animator animator)
    {
        _animator = animator;
        foreach (PlayerAnimationType animationType in Enum.GetValues(typeof(PlayerAnimationType)))
        {
            _animationHash.Add(animationType, Animator.StringToHash(animationType.ToString()));
        }
    }

    public void SetBool(PlayerAnimationType animationType, bool value)
    {
        _animator.SetBool(_animationHash[animationType], value);
    }
}