using UnityEngine;
using UnityEngine.UI;

namespace ProcketZone2.UI
{
    public class HealthBar : UIEntity
    {
        [SerializeField] private Transform _target;
        [SerializeField] private Slider slider;
        private float _maxHP;

        private Vector3 _offset;

        public void Init(Transform target, Vector2 offset)
        {
            _target = target;
            _offset = new Vector3(offset.x, offset.y, 0);
        }
        private void LateUpdate()
        {
            transform.position = _target.position + _offset;
        }
        public void ChangeValue(int health)
        {
            slider.value = health / _maxHP;
        }
        public void SetMaxHealth(int maxHP)
        {
            _maxHP = maxHP;
        }
    }

}
