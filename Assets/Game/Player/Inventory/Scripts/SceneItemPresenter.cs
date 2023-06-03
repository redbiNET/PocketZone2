using UnityEngine;

namespace ProcketZone2.Player.Items
{
    public class SceneItemPresenter : Entity
    {
        [SerializeField] private int _count;
        public int Count => _count;
        
        [SerializeField] private Item _item;
        public Item Item => _item;

        [SerializeField] private MovingAloneCurve _movingCurve;

        [SerializeField] private bool _enable;
        public void Init(Item item, int count)
        {
            _item = item;
            _count = count;
            GetComponent<SpriteRenderer>().sprite = item.Icon;
            _movingCurve.StartMove().OnComplete(() => _enable = true);
        }
        public Item GetItem()
        {
            if (!_enable) return null;
            _count--;
            if (_count <= 0) Destroy(this);
            return _item;
        }
    }

}
