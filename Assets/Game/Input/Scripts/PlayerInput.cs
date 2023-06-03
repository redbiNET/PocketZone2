
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace ProcketZone2.GameInput
{
    public abstract class PlayerInput : MonoBehaviour
    {
        private static PlayerInput _instance;

        public static PlayerInput Instance
        {
            get
            {
                if (_instance == null) _instance = FindObjectOfType<PlayerInput>();
                return _instance;
            }
            set
            {
                if (_instance == null) _instance = value;
                else if (_instance != value) Destroy(value);
            }
        }
        private readonly Dictionary<EventKey, UnityEvent> _events = new Dictionary<EventKey, UnityEvent>();

        private void Awake()
        {
            Instance = this;
        }

        public Vector2 Drag => GetDragDelta();
        public Vector2 Direction => GetDirection();
        public Vector2 DirectionRaw => GetDirectionRaw();

        protected abstract Vector2 GetDragDelta();
        protected abstract Vector2 GetDirection();
        protected abstract Vector2 GetDirectionRaw();

        public static void AddAction(UnityAction action, EventKey key)
        {
            Instance.GetEvent(key).AddListener(action);
        }
        public static void RemoveAction(UnityAction action, EventKey key)
        {
            Instance.GetEvent(key).RemoveListener(action);
        }
        protected UnityEvent GetEvent(EventKey key)
        {
            if(_events.TryGetValue(key, out UnityEvent unityEvent))
            {
                return unityEvent;
            }
            else return _events[key] = new UnityEvent();
        }
    }
}


public enum EventKey
{
    GamePause,
    ShootDown,
    ShootUp
}
