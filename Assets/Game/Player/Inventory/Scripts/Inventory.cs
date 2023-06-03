using System; 
using UnityEngine;

namespace ProcketZone2.Player.Items
{
    [Serializable]
    public class Inventory 
    {
        public Cell[,] _cells;
        [SerializeField] private Cell[] _cellsSave;

        [SerializeField] private Vector2Int _inventorySize = new Vector2Int(4,4);

        public Cell[,] GetCells()
        {
            if(_cells == null)
            {
                _cells = new Cell[_inventorySize.x, _inventorySize.y];
                for (int y = 0; y < _inventorySize.x; y++)
                {
                    for (int x = 0; x < _inventorySize.y; x++)
                    { 
                        _cells[x, y] = _cellsSave[y * _inventorySize.y + x];
                    }
                }
            }
            return _cells;
        }
        public void Init(Vector2Int size)
        {
            _inventorySize = size;
            _cells = new Cell[_inventorySize.x, _inventorySize.y];
            _cellsSave = new Cell[_inventorySize.x * _inventorySize.y];

            for (int y = 0; y < _inventorySize.x; y++)
            {
                for (int x = 0; x < _inventorySize.y; x++)
                {
                    _cells[x, y] = new Cell();
                    _cellsSave[y * _inventorySize.y + x] = _cells[x, y];
                }
            }
        }
        public bool AddItem(Item item)
        {
            for (int y = 0; y < _inventorySize.x; y++)
            {
                for (int x = 0; x < _inventorySize.y; x++)
                {
                    if (_cells[x,y].EqualItem(item))
                    {
                        if (!_cells[x, y].AddItem(item)) continue;
                        else return true;
                    }
                }
            }
            for (int y = 0; y < _inventorySize.x; y++)
            {
                for (int x = 0; x < _inventorySize.y; x++)
                {
                    if (_cells[x, y].IsFree)
                    {
                        _cells[x, y].AddItem(item);
                        return true;
                    }
                }
            }
            return false;
        }
        public bool GetItem(Item item)
        {
            for (int y = 0; y < _inventorySize.x; y++)
            {
                for (int x = 0; x < _inventorySize.y; x++)
                {
                    if (_cells[x, y].EqualItem(item))
                    {
                        _cells[x, y].GetItem();
                        return true;
                    }
                }
            }
            return false;
        }
    }
}
