using ProcketZone2.GameInput;
using UnityEngine;

namespace ProcketZone2.Weapon
{
    public class SingleShooting : Shooting
    {
        public override void Update()
        {
            _curentDelay += Time.deltaTime;
        }
        public void TryShoot()
        {
            if(_curentDelay >= _delay)
            {
                _curentDelay = 0;
                Shoot();
            }

        }

        public override void Enable()
        {
            PlayerInput.AddAction(TryShoot, EventKey.ShootDown);
        }

        public override void Disable()
        {
            PlayerInput.RemoveAction(TryShoot, EventKey.ShootDown);
        }
    }
}