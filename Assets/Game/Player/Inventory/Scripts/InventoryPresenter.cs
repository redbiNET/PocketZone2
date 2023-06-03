using UnityEngine;

namespace ProcketZone2.Player.Items
{
    public class InventoryPresenter : MonoBehaviour
    {
        [SerializeField] ItemRemover _itemRemover;
        [SerializeField] CellPresenter _cellPresenter;
        private CellPresenter[,] _cells;

        [SerializeField] private Vector2 _distanceBetweenCells;
        public void Init(CellController[,] cells)
        {
            Vector2Int size = new Vector2Int(cells.GetLength(0), cells.GetLength(1));
            _cells = new CellPresenter[size.y, size.x];
            for (int y = 0; y < size.y; y++)
            {
                for (int x = 0; x < size.x; x++)
                {
                    Vector2 position = transform.position + new Vector3(_distanceBetweenCells.x * x, _distanceBetweenCells.y * y);
                    CellPresenter presenter = Instantiate(_cellPresenter, position, Quaternion.identity, transform);

                    cells[x,y].SetPresenter(presenter);
                    presenter.OnChoosing += (Cell) => _itemRemover.GetCell(Cell);
                    _cells[x,y] = presenter;
                }
            }
        }
    }
}