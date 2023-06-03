using UnityEngine;

namespace ProcketZone2.Weapon
{
    public class Recoil : MonoBehaviour
    {
        [SerializeField] private AnimationCurve _movingCurve = AnimationCurve.EaseInOut(0,0,1,1);
        [SerializeField] private float _moveSpeed;
        [SerializeField] private float _power = 1f;

        private float _time;
        private float _currentTime;
        private Vector3 _startPosition;

        private bool _isMoving;
        private bool _returnOnEnd;

        private void Awake()
        {
            _startPosition = transform.localPosition;
        }
        public Recoil StartMove(float time)
        {
            if (_isMoving) return this;
            _time = time;
            _isMoving = true;
            return this;
        }

        private void Update()
        {
            if (_isMoving)
            {
                Move();
            }
        }

        private void Move()
        {
            _currentTime += Time.deltaTime * 1/_time;
            if(_currentTime > 1)
            {
                ResetValues();
            }
            else
            {
                float moving = _movingCurve.Evaluate(_currentTime);
                transform.localPosition = new Vector3(_startPosition.x - moving*_power, transform.localPosition.y, transform.localPosition.z);
            }
        }
        public Recoil ReturnAfterEnd()
        {
            _returnOnEnd = true;
            return this;
        }
        private void ResetValues()
        {
            if(_returnOnEnd) transform.localPosition = _startPosition;
            _currentTime = 0;
            _isMoving = false;
            _returnOnEnd=false;
        }
    }
}