using ProcketZone2.Player;
using ProcketZone2.Player.Items;
using ProcketZone2.UI;
using System.Collections.Generic;
using UnityEngine;

namespace ProcketZone2.Weapon
{
    public class Gun : MonoBehaviour
    {
        [SerializeField] private int _maxMagazineCapacity;
        private int _magazineCapacity;
        [SerializeField] private float _reloadTime;

        [SerializeField] private ShootType[] _shootTypes;

        private Dictionary<ShootType, Shooting> _shootings;
        private Shooting _currentShooting;

        [SerializeField] private Transform _shootTransform;
        [SerializeField] private float _shootDistance;
        [SerializeField] private int _damage;
        [SerializeField] private float _delay;
        
        [SerializeField] private float _scatter;

        private InventoryController _inventory;
        [SerializeField] private Item _bullet;
        [SerializeField] private Recoil _recoil;
        [SerializeField] private Aim _aim;

        [SerializeField] private Transform _leftArmTarget;
        [SerializeField] private Transform _rightArmTarget;

        [SerializeField] private LayerMask _obstacleMask;

        public void Init(InventoryController inventory, ArmTarget leftArmTarget, ArmTarget rightArmTarget)
        {
            _magazineCapacity = _maxMagazineCapacity;
            leftArmTarget.SetTarget(_leftArmTarget);
            rightArmTarget.SetTarget(_rightArmTarget);
            _inventory = inventory;
            _shootings = new Dictionary<ShootType, Shooting>();
            foreach (ShootType shootType in _shootTypes)
            {
                _shootings.Add(shootType, Shooting.Get(shootType, _shootTransform, _inventory, _bullet, _shootDistance, _delay, _scatter, _damage, _obstacleMask, Shoot));
            }
            ChangeShootType(_shootTypes[0]);
            _aim = UIEntity.Instantiate(_aim);
            _aim.Init(_shootTransform, _scatter, _shootDistance);
        }
        public void Shoot()
        {
            _magazineCapacity--;
            if (_magazineCapacity <= 0)
            {
                _currentShooting.enable = false;
                Invoke("Reload", _reloadTime);
            }
            _recoil.StartMove(_delay).ReturnAfterEnd();
        }
        private void Reload()
        {
            _currentShooting.enable = true;
            _magazineCapacity = _maxMagazineCapacity;
        }
        private void ChangeShootType(ShootType type)
        {
            if(_currentShooting != null) _currentShooting.Disable();
            _currentShooting = _shootings[type];
            _currentShooting.Enable();
        }
        public void Update()
        {
            _currentShooting.Update();
        }
    }
    public enum ShootType
    {
        Automatic,
        Single
    }
}


