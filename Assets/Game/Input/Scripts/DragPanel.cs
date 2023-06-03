using UnityEngine;
using UnityEngine.EventSystems;

namespace ProcketZone2.GameInput
{
    public class DragPanel : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
    {
        public Vector2 Delta { get; private set; }
        private Vector2 _lastPosition;

        private bool _isDragging;
    

        public void OnPointerUp(PointerEventData eventData)
        {
            Delta = Vector2.zero;
            _isDragging = false;
        }

        public void Update()
        {
            if (_isDragging)
            {
                Vector2 position = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
                Delta = position - _lastPosition;
                _lastPosition = position;
            }


        }

        public void OnPointerDown(PointerEventData eventData)
        {
            _lastPosition = Input.mousePosition;
            _isDragging = true;
        }
    }
}

