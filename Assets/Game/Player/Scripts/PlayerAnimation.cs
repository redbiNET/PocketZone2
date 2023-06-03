using System;
using UnityEngine;

namespace ProcketZone2.Player
{
    [Serializable]
    internal class PlayerAnimation
    {
        [SerializeField] private Animator _animator;

        public void SetSpeed(float speed)
        {
            _animator.SetFloat("Speed", speed);
        }
    }
}