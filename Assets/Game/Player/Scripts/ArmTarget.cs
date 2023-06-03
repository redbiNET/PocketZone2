using UnityEngine;

namespace ProcketZone2.Player
{
    public class ArmTarget : MonoBehaviour
    {
        [SerializeField] private Transform _armTarget;
        public void SetTarget(Transform armTarget)
        {
            _armTarget = armTarget;
        }

        private void Update()
        {
            transform.position = _armTarget.position;
        }

    }
}

