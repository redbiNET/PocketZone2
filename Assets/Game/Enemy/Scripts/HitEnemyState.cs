using System;
using UnityEngine;
using ProcketZone2.Weapon;

namespace ProcketZone2.Enemys
{
    [Serializable]
    internal class HitEnemyState : EnemyState
    {
        [SerializeField] private float _hitDistance;
        [SerializeField] private int _damage;
        [SerializeField] private AttackTrigger _attackTrigger;

        private float _currentDelay;

        private bool _canHit = true;

        protected override void Start()
        {
            _attackTrigger.Init(Hit, _hitDistance);
        }
        public override void Disable()
        {
            _attackTrigger.Disable();
        }

        public override void Enable()
        {
            _attackTrigger.Enable();
        }
        private void Hit(IDamageble damageble)
        {
            damageble.GetDamage(_damage);
            _attackTrigger.Disable();
            
        }
        private void UnlockHit()
        {
            _currentDelay = 0;
            _canHit = true;
        }
        public override void Update()
        {
            if (_canHit)
            {
                Collider2D collider = Physics2D.OverlapCircle(center.position, _hitDistance, stateMachine.PlayerMask);
                if (collider)
                {
                    _attackTrigger.Enable();
                    stateMachine.Animation.Hit();
                    _canHit = false;
                }
                else
                {
                    stateMachine.ChangeState(stateMachine.FollowState);
                }
            }
            else
            {
                _currentDelay += Time.deltaTime;
                if(_currentDelay >= 1)
                {
                    UnlockHit();
                }
            }

        }
    }
}