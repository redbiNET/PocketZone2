using Pathfinding;
using System;
using UnityEngine;

namespace ProcketZone2.Enemys
{
    [Serializable]
    internal class EnemyMovement
    {
        [SerializeField] private float _speed;
        [SerializeField] private AIDestinationSetter _destinationSetter;
        [SerializeField] private AIPath _path;
        private EnemyAnimation _animation;
        private Transform _transform;

        public void Init(Transform transform, EnemyAnimation animation)
        {
            _transform = transform;
            _animation = animation;
        }
        public void SetTarget(Transform target)
        {
            _destinationSetter.target = target;
        }
        public void Update()
        {
            Vector2 direction = _path.desiredVelocity;
            if(direction.x < 0)
            {
                _transform.localScale = new Vector3(-1, 1, 1);
            }
            else if(direction.x > 0)
            {
                _transform.localScale = new Vector3(1, 1, 1);
            }
        }
        public void Disable()
        {
            _path.maxSpeed = 0; 
            _animation.SetSpeed(0);
        }
        public void Enable()
        {
            _path.maxSpeed = _speed;
            _animation.SetSpeed(1);

        }
    }
}