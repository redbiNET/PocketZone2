using UnityEngine;

namespace ProcketZone2.Player.Items
{
    [CreateAssetMenu(menuName = "ItemSpawner")]
    public class ItemSpawner : ScriptableObject
    {
        [SerializeField] private SceneItemPresenter _presenter;
        [SerializeField] private Item[] _items;
        public void SpawnRandomItem(Vector3 position)
        {
            int index = Random.Range(0, _items.Length);
            SceneItemPresenter presenter = Entity.Instantiate(_presenter, position, Quaternion.identity);
            presenter.Init(_items[index], 1);
        }
    }
}

