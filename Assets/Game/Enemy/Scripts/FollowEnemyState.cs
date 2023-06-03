using System;
using UnityEngine;

namespace ProcketZone2.Enemys
{
    [Serializable]
    public class FollowEnemyState : EnemyState
    {
        [SerializeField] private float _visibilityDistance;
        [SerializeField] private float _hitDistance;
        [SerializeField] private EnemyMovement _movement;

        private bool _enable;

        protected override void Start()
        {
            _movement.Init(transform, stateMachine.Animation);
        }
        public override void Disable()
        {
            _enable = false;
            _movement.Disable();
        }

        public override void Enable()
        {
            _enable = true;
            Collider2D collider = Physics2D.OverlapCircle(center.position, _visibilityDistance, stateMachine.PlayerMask);
            if (collider != null)
            {
                _movement.SetTarget(collider.transform.root);
            }
            else stateMachine.ChangeState(stateMachine.IdleState);
            _movement.Enable();

        }
        public override void Update()
        {
            if (!_enable) return;
            if(Physics2D.OverlapCircle(center.position, _hitDistance, stateMachine.PlayerMask))
            {
                stateMachine.ChangeState(stateMachine.HitState);
            }
            _movement.Update();
        }
    }
}