using ProcketZone2.GameInput;
using ProcketZone2.Player.Items;
using ProcketZone2.UI;
using ProcketZone2.Weapon;
using UnityEngine;
using UnityEngine.Events;

namespace ProcketZone2.Player
{
    public class Player : Entity
    {
        [SerializeField] private Transform _center;
        [SerializeField] private ArmTarget _leftArmTarget;
        [SerializeField] private ArmTarget _rightArmTarget;
        [SerializeField] private HealthBar _healthBar;
        [SerializeField] private Vector2 _healthBarOffset;
        [SerializeField] private Health _playerHP;
        [SerializeField] private PlayerMovement _playerMovement;
        [SerializeField] private InventoryController _inventory;
        [SerializeField] private Gun _gun;
        [SerializeField] private Aimer _aimer;

        [SerializeField] private float _puckUpDistance;
        [SerializeField] private LayerMask _itemMask;
        public UnityEvent OnDie { get; } = new UnityEvent();
        private void Start()
        {
            _aimer.Init(_center);
            _inventory.Init();
            _gun.Init(_inventory,_leftArmTarget, _rightArmTarget);
            _playerMovement.Init(transform);
            _playerHP.OnHealthOver.AddListener(Die);
            HealthBar bar = UIEntity.Instantiate(_healthBar);
            bar.Init(transform, _healthBarOffset);
            _playerHP.Init(GetComponentsInChildren<IDamageGetter>(), bar);

        }
        private void FixedUpdate()
        {
            Transform target = _aimer.FindEnemy();
            Vector3 direction = PlayerInput.Instance.Direction;
            if (target != null)
            {
                direction = (target.position - transform.position).normalized;
            }
            _playerMovement.FixedUpdate();
            _playerMovement.Rotate(direction);
            Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, _puckUpDistance, _itemMask);
            foreach (Collider2D item in colliders)
            {
                PickUpItem(item);
            }
        }
        private void PickUpItem(Collider2D collider)
        {

            if (collider != null)
            {
                if(collider.TryGetComponent<SceneItemPresenter>(out SceneItemPresenter itemPresenter))
                {
                    Item item = itemPresenter.GetItem();
                    if (item != null) _inventory.AddItem(item);
                    
                }
            }
        }
        private void Die()
        {
            OnDie.Invoke();
        }
        public void SaveParameters()
        {
            _inventory.Save();
        }
    }
}

