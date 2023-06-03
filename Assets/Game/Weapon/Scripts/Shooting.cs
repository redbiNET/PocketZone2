using ProcketZone2.Player;
using ProcketZone2.Player.Items;
using System;
using UnityEngine;

namespace ProcketZone2.Weapon
{
    public abstract class Shooting
    {
        private InventoryController _inventory;        
        [SerializeField] protected Item _bullet;
        protected Transform transform;
        protected float _shootDistance;
        protected float _delay;
        protected float _curentDelay;
        protected int _damage;
        private float _scatter;
        private Action _onShoot;
        private LayerMask _obstacleMask;

        protected bool _isShoot;
        public bool enable = true;

        public void Init(Transform transform, InventoryController inventory, Item bullet, float shootDistance, float delay, float scatter, int damage, LayerMask obstacleMask, Action OnShoot)
        {
            this.transform = transform;
            _inventory = inventory;
            _bullet = bullet;
            _shootDistance = shootDistance;
            _delay = delay;
            _scatter = scatter;
            _damage = damage;
            _obstacleMask = obstacleMask;
            _onShoot = OnShoot;
        }
        public static Shooting Get(ShootType type, Transform transform, InventoryController inventory, Item bullet, float shootDistance, float delay, float scatter, int damage, LayerMask obstacleMask, Action OnShoot)
        {
            Shooting shooting = null;
            switch (type)
            {
                case ShootType.Automatic:
                    shooting = new AutomaticShooting();
                    shooting.Init(transform, inventory, bullet, shootDistance, delay, scatter, damage, obstacleMask, OnShoot);
                    break;
                case ShootType.Single:
                    shooting = new SingleShooting();
                    shooting.Init(transform, inventory, bullet, shootDistance, delay, scatter, damage, obstacleMask, OnShoot);
                    break;
                default:
                    break;
            }
            return shooting;
        }
        protected void Shoot()
        {
            if(enable && _inventory.GetItem(_bullet))
            {
                Vector3 direction = transform.right * PlayerMovement.Direction;
                float scatter = UnityEngine.Random.Range(-_scatter, _scatter);
                direction = Quaternion.Euler(0, 0, scatter) * direction;
                RaycastHit2D collider = Physics2D.Raycast(transform.position, direction, distance: _shootDistance, _obstacleMask);
                if (collider.collider != null)
                {
                    if (collider.collider.gameObject.TryGetComponent<IDamageble>(out IDamageble damageble))
                    {
                        damageble.GetDamage(_damage);
                    }
                }
                _onShoot.Invoke();
            }

        }

        public abstract void Update();
        public abstract void Enable();
        public abstract void Disable();

    }
}

