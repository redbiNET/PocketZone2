using System;
using UnityEngine;

namespace ProcketZone2.Player.Items
{
    [CreateAssetMenu(menuName = "Item")]
    [Serializable]
    public class Item : ScriptableObject
    {
        [SerializeField] private string _name;
        [SerializeField] private Sprite _icon;
        public Sprite Icon => _icon;

        [SerializeField] private int _maxItemCountInStach;
        public int MaxItemCountInStack => _maxItemCountInStach;

        public override bool Equals(object obj)
        {
            Item item = obj as Item;
            return item._name == _name;
        }
    }
}