namespace ProcketZone2.Player.Items
{
    public class CellController
    {
        private Cell _cell;
        private CellPresenter _presenter;
        public int Count => _cell.Count;
        public bool IsFree => _cell.IsFree;

        public CellController(Cell cell)
        {
            _cell = cell;
            _cell.OnCountChanged.AddListener((count) => _presenter.UpdateCount(count));
            _cell.OnItemChanged.AddListener(UpdateSprite);
        }
        private void UpdateSprite(Item item)
        {
            if (item == null)
            {
                _presenter.UpdateSprite(null);
                return;
            }
            _presenter.UpdateSprite(item.Icon);
        }
        public void SetPresenter(CellPresenter presenter)
        {
            if(_presenter == null)
            {
                presenter.Init(this);
                _presenter = presenter;
                UpdateSprite(_cell.Item);
                _presenter.UpdateCount(_cell.Count);
            }

        }
        public void GetItem()
        {
            _cell.GetItem();
        }
        public void AddItem(Item item)
        {
            _cell.AddItem(item);
        }
    }
}