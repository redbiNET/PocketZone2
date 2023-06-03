using System;
using UnityEngine;

namespace ProcketZone2.Enemys
{
    [Serializable]
    internal class IdleEnemyState : EnemyState
    {
        [SerializeField] private float _visibilityDistance;

        private bool _enable;

        public override void Disable()
        {
            _enable = false;
        }

        public override void Enable()
        {
            _enable = true;
        }

        public override void Update()
        {
            if (!_enable) return;
            Collider2D collider = Physics2D.OverlapCircle(center.position, _visibilityDistance, stateMachine.PlayerMask);
            if (collider != null) stateMachine.ChangeState(stateMachine.FollowState);
        }
    }
}