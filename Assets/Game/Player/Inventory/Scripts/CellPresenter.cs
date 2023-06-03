using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace ProcketZone2.Player.Items
{
    public class CellPresenter : MonoBehaviour
    {
        [SerializeField] private Image _icon;
        [SerializeField] private Sprite _defaultIcon;
        [SerializeField] private TextMeshProUGUI _textCount;
        private CellController _cell;
        public int Count => _cell.Count;
        public bool IsFree => _cell.IsFree;

        public delegate void ChoosingCell(CellPresenter cell);
        public event ChoosingCell OnChoosing;

        public void Init(CellController cell)
        {
            _cell = cell;
        }
        public void Choose()
        {
            OnChoosing.Invoke(this);
        }
        public void GetItem()
        {
            _cell.GetItem();
        }
        public void UpdateCount(int value)
        {
            _textCount.text = value > 1 ? value.ToString() : "";
        }
        public void UpdateSprite(Sprite sprite)
        {
            if(sprite == null)
            {
                _icon.sprite = _defaultIcon;
                return;
            }
            _icon.sprite = sprite;
        }
    }
}