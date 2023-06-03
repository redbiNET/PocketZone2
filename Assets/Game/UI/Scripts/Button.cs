using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

namespace ProcketZone2.UI
{
    public class Button : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
    {
        public UnityEvent OnDown;
        public UnityEvent OnUp;

        public void OnPointerDown(PointerEventData eventData)
        {
            OnDown.Invoke();
        }

        public void OnPointerUp(PointerEventData eventData)
        {
            OnUp.Invoke();
        }
    }
}

