using ProcketZone2;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSorter : MonoBehaviour
{
    [SerializeField] private List<Entity> _objectsToSort;

    private static ObjectSorter _instance;

    private void Awake()
    {
        if (_instance == null) _instance = this;
        else Destroy(this);
    }
    private void Start()
    {
        Entity[] entities = FindObjectsOfType<Entity>();
        foreach (Entity entity in entities)
        {
            SubscribeEntity(entity);
        }

    }
    private void Update()
    {
        Sort();
    }
    private void Sort()
    {
        foreach (MonoBehaviour obj in _objectsToSort)
        {
            SorObject(obj);
        }
    }
    private void SorObject(MonoBehaviour obj)
    {
        Vector3 position = obj.transform.position;
        position.z = position.y / 1000;
        obj.transform.position = position;
    }
    public static void SubscribeEntity(Entity entity)
    {
        _instance._objectsToSort.Add(entity);
    }
    public static void UnSubscribeEntity(Entity entity)
    {
        _instance._objectsToSort.Remove(entity);
    }
}
