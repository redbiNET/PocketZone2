using UnityEngine.UI;
using ProcketZone2.UI;
using TMPro;
using UnityEngine;

namespace ProcketZone2.Player.Items
{
    public class ItemRemover : Form
    {
        private CellPresenter _cell;
        [SerializeField] private Slider _itemCount;
        [SerializeField] private TextMeshProUGUI _itemCountOutput;

        private void Awake()
        {
            Close();
        }
        public void GetCell(CellPresenter cell)
        {
            _cell = cell;
            PresentCountItem();
            Open();
        }
        public void PresentCountItem()
        {
            int count = Mathf.RoundToInt(_cell.Count * _itemCount.value);
            _itemCountOutput.text = count.ToString();
        }
        public void DeleteItems()
        {
            int count = Mathf.RoundToInt(_cell.Count * _itemCount.value);

            for(int i = 0; i < count; i++)
            {
                _cell.GetItem();
            }
            Close();
        }
        public override void Close()
        {
            _cell = null;
            gameObject.SetActive(false);
        }

        public override void Open()
        {
            if (!_cell.IsFree)
            {
                gameObject.SetActive(true);
            }
            else Close();
        }
    }
}

