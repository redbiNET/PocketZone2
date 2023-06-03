using ProcketZone2.UI;
using UnityEngine;

namespace ProcketZone2.GameInput
{
    public class MobilePlayerInput : PlayerInput
    {
        [SerializeField] private Joystick _joystick;
        [SerializeField] private DragPanel _dragPanel;
        [SerializeField] private Button _shootButton;

        private void Awake()
        {
            _shootButton.OnDown.AddListener(GetEvent(EventKey.ShootDown).Invoke);
            _shootButton.OnUp.AddListener(GetEvent(EventKey.ShootUp).Invoke);
        }

        protected override Vector2 GetDragDelta()
        {
            return _dragPanel.Delta;
        }

        protected override Vector2 GetDirection()
        {
            return _joystick.Direction; 
        }

        protected override Vector2 GetDirectionRaw()
        {
            return _joystick.Direction.normalized;
        }
    }
}
