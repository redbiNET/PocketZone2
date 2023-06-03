using UnityEngine;
using UnityEngine.Events;

namespace ProcketZone2
{
    public class MovingAloneCurve : MonoBehaviour
    {
        [SerializeField] private AnimationCurve _movingCurve;
        [SerializeField] private float _minMoveDistance;
        [SerializeField] private float _maxMoveDistance;
        [SerializeField] private float _minAmplitude;
        [SerializeField] private float _maxAmplitude;
        [SerializeField] private float _duration;

        private Vector3 _startPos;
        private float _direction;
        private float _distance;
        private float _amplitude;
        private float _time;
        private UnityAction _onComplete;
        private bool _isMoving;

        public MovingAloneCurve StartMove()
        {
            _isMoving = true;
            _startPos = transform.position;
            _direction = Random.Range(-1, 2);
            _distance = Random.Range(_minMoveDistance, _maxMoveDistance);
            _amplitude = Random.Range(_minAmplitude, _maxAmplitude);
            return this;
        }
        public void Update()
        {
            if(!_isMoving) return;
            _time += Time.deltaTime / _duration;
            if(_time > 1)
            {
                _onComplete.Invoke();
                Destroy(this);
            }
            else
            {
                float y = _movingCurve.Evaluate(_time);
                transform.position = _startPos + new Vector3(_time * _distance * _direction, y * _amplitude, 0);
            }
        }
        public MovingAloneCurve OnComplete(UnityAction action)
        {
            _onComplete = action;
            return this;
        }
    }
}