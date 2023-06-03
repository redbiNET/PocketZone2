using ProcketZone2.Player;
using ProcketZone2.UI;
using UnityEngine;
using UnityEngine.UI;

namespace ProcketZone2.Weapon
{
    public class Aim : UIEntity
    {
        [SerializeField] private Image _aimImage;
        private float _scatter;
        private float _distance;
        private Transform _target;

        public void Init(Transform target, float scatter, float distance)
        {
            _target = target;
            GetScatterAngle(scatter);
            GetDistanceAngle(distance);
        }
        public void GetScatterAngle(float scatter)
        {
            _scatter = scatter;
            _aimImage.fillAmount = _scatter*2/360;               
        }
        public void GetDistanceAngle(float distance)
        {
            _distance = distance;
            transform.localScale = new Vector3(_distance,_distance, 1);
        }

        private void LateUpdate()
        {
            transform.position = _target.position;
            transform.right = Quaternion.Euler(0,0, _scatter) * _target.right * PlayerMovement.Direction;
        }
    }

}
