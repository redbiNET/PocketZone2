using System;
using UnityEngine;

[Serializable]
public class EnemyAnimation
{
    [SerializeField] private Animator _animator;             

    [SerializeField] private string _speedKey = "Speed";
    [SerializeField] private string _hitKey = "Hit";

    public void SetSpeed(float speed)
    {
        _animator.SetFloat(_speedKey, speed);
    }
    public void Hit()
    {
        _animator.SetTrigger(_hitKey);
    }
}
