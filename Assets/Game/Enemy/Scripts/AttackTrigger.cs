using UnityEngine;

namespace ProcketZone2.Weapon
{
    public class AttackTrigger : MonoBehaviour
    {
        private float _attackDistance;

        [SerializeField] private LayerMask _attackLayerMask;
        private bool _enabled;

        public delegate void HitTriggerDelegate(IDamageble damageble);
        public HitTriggerDelegate OnDamagebleDetect;

        public void Init(HitTriggerDelegate attack, float attackDistance)
        {
            OnDamagebleDetect = attack;
            _attackDistance = attackDistance;
        }
        public void Enable()
        {
            _enabled = true;
        }
        public void Disable()
        {
            _enabled = false;
        }
        private void Update()
        {
            if (!_enabled) return;
            Collider2D collider = Physics2D.OverlapCircle(transform.position, _attackDistance, _attackLayerMask);
            if (collider)
            {
                OnDamagebleDetect(collider.gameObject.GetComponent<IDamageble>());
            }
        }
        private void OnDrawGizmos()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(transform.position, _attackDistance);
        }
    }
}

