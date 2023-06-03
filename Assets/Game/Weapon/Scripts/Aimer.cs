using ProcketZone2.Enemys;
using ProcketZone2.GameInput;
using UnityEngine;

namespace ProcketZone2.Player
{
    public class Aimer : MonoBehaviour
    {
        private Transform _center;
        [SerializeField] private float _visibilityDistance;
        [SerializeField] private float _rotateSpeed;
        [SerializeField] private LayerMask _enemyMask;
        [SerializeField] private Vector2 _rotateRange;
        private Transform _target;

        public void Init(Transform center)
        {
            _center = center;
        }
        public Transform FindEnemy()
        {
            Vector2 axis = PlayerInput.Instance.DirectionRaw;
            Collider2D[] colliders = Physics2D.OverlapCircleAll(_center.position, _visibilityDistance, _enemyMask);
            Transform target = null;
            if(colliders.Length > 0)
            {
                float distance = 0;
                if (_target != null && Vector3.Distance(transform.position, _target.position) < _visibilityDistance) target = _target;
                else target = colliders[0].transform.root;
                distance = (target.position - transform.position).magnitude;
                foreach (Collider2D enemy in colliders)
                {
                    float dist = (enemy.transform.root.position - transform.position).magnitude;
                    if(distance - dist > 0.5f)
                    {
                        target = enemy.transform.root;
                        distance = dist;
                    }
                }
            }
            Transform center = null;
            if (target != null)
            {

                if (target.transform.root.TryGetComponent<Enemy>(out Enemy enemy))
                {
                    _target = target;
                    center = enemy.Center;
                }
                else center = target.transform;
                Rotate((center.position - transform.position).normalized);
                return center;

            }
            Rotate(axis);
            return center;
        }
        public void Rotate(Vector3 direction)
        {
            if (direction.magnitude > 0)
            {
                float angle = Mathf.Asin(direction.y) * Mathf.Rad2Deg;
                angle = Mathf.Clamp(angle, _rotateRange.x, _rotateRange.y);
                Quaternion quaternion = Quaternion.RotateTowards(transform.localRotation, Quaternion.Euler(0, 0, angle), _rotateSpeed);
                transform.localRotation = quaternion;
            }
        }
    }
}

