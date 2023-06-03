using System;
using UnityEngine;

namespace ProcketZone2.Player.Items
{
    [Serializable]
    public class InventoryController 
    {
        private Inventory _inventory;
        [SerializeField] private InventoryPresenter _presenter;

        private CellController[,] _cells;
        [SerializeField] private Vector2Int _size;

        public void Init()
        {
            _inventory = InventorySaver.Get(_size);
            Cell[,] cells = _inventory.GetCells();

            Vector2Int size = new Vector2Int(cells.GetLength(0), cells.GetLength(1));
            _cells = new CellController[size.x, size.y];
            for (int x = 0; x < size.x; x++)
            {
                for (int y = 0; y < size.y; y++)
                {
                    _cells[x, y] = new CellController(cells[x,y]);
                }
            }
            _presenter.Init(_cells);
        }
        public bool AddItem(Item item)
        {
            return _inventory.AddItem(item);
        }
        public bool GetItem(Item item)
        {
            return _inventory.GetItem(item);
        }
        public void Save()
        {
            InventorySaver.Save(_inventory);
        }
    }
}

