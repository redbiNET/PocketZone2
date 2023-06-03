using System;
using UnityEngine;
using UnityEngine.Events;

namespace ProcketZone2.Player.Items
{
    [Serializable]
    public class Cell
    {
        public UnityEvent<int> OnCountChanged = new UnityEvent<int>();
        public UnityEvent<Item> OnItemChanged = new UnityEvent<Item>();
        [SerializeField] private int _count;
        public int Count
        {
            get
            {
                return _count;
            }
            set
            {
                OnCountChanged?.Invoke(value);
                _count = value;
            }
        }
        [SerializeField] private Item _item;
        public Item Item => _item;
        public bool IsFree => _item == null;

        public Cell()
        {
            OnItemChanged.Invoke(_item);
            Count = 0;
        }
        public bool EqualItem(Item item)
        {
            if(item == null) return false;
            return item == _item;
        }
        public bool AddItem(Item item)
        {
            if (_item == null)
            {
                OnItemChanged?.Invoke(item);
                _item = item;
            }
            if (_item == item && Count < _item.MaxItemCountInStack)
            {
                Count++;
                return true;
            }
            return false;
        }
        public void GetItem()
        {
            Count--;
            if (Count <= 0)
            {
                OnItemChanged.Invoke(null);
                _item = null;
            }
        }

    }
}
