using ProcketZone2.GameInput;
using System;
using UnityEngine;

namespace ProcketZone2.Player
{
    [Serializable]
    public class PlayerMovement
    {
        [SerializeField] private float _speed;
        [SerializeField] private PlayerAnimation _animation;

        private Rigidbody2D _rb;

        private PlayerInput _input;
        private Transform _transform;

        public static int Direction { get; private set; }
        public void Init(Transform transform)
        {
            _transform = transform;
            _rb = transform.GetComponent<Rigidbody2D>();
            _input = PlayerInput.Instance;
        }
        public void FixedUpdate()
        {
            Vector2 axis = _input.Direction;
            _rb.velocity = axis * _speed * Time.fixedDeltaTime;
            _animation.SetSpeed(axis.magnitude);
        }
        public void Rotate(Vector3 direction)
        {
            if (direction.x < 0)
            {
                _transform.localScale = new Vector3(-1, 1, 1);
                Direction = -1;
            } 
            if (direction.x > 0)
            {
                _transform.localScale = new Vector3(1, 1, 1);
                Direction = 1;
            }

        }
    }
}

