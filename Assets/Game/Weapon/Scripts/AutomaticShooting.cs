using ProcketZone2.GameInput;
using UnityEngine;

namespace ProcketZone2.Weapon
{
    internal class AutomaticShooting : Shooting
    {
        public override void Update()
        {
            if (!_isShoot) return;
            _curentDelay += Time.deltaTime;
            if (_curentDelay >= _delay)
            {
                _curentDelay = 0;
                Shoot();
            }
        }
        public void TryShoot()
        {
            _curentDelay = _delay;
            _isShoot = true;
        }
        public void StopShoot()
        {
            _isShoot = false;
        }

        public override void Enable()
        {
            PlayerInput.AddAction(TryShoot, EventKey.ShootDown);
            PlayerInput.AddAction(StopShoot, EventKey.ShootUp);
        }

        public override void Disable()
        {
            PlayerInput.RemoveAction(TryShoot, EventKey.ShootDown);
            PlayerInput.RemoveAction(StopShoot, EventKey.ShootUp);
        }
    }
}