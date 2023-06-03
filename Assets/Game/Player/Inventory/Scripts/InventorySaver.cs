using System.IO;
using UnityEngine;

namespace ProcketZone2.Player.Items
{
    public static class InventorySaver
    {
        public static void Save(Inventory inventory)
        {
            string path = Application.persistentDataPath + "/Inventory.json";
            string content = JsonUtility.ToJson(inventory);
            File.WriteAllText(path, content);
        }
        public static Inventory Get(Vector2Int defaultSize)
        {
            string path = Application.persistentDataPath + "/Inventory.json";
            if (File.Exists(path))
            {
                return JsonUtility.FromJson<Inventory>(File.ReadAllText(path));
            }

            else
            {
                Inventory inventory = new Inventory();
                inventory.Init(defaultSize);
                return inventory;
            }
        }
    }
}

