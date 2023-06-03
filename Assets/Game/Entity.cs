using UnityEngine;

namespace ProcketZone2
{
    public class Entity : MonoBehaviour
    {
        public void Sort(float position)
        {
            Vector3 direction = transform.position;
            direction.z = position;
            transform.position = direction;
        }

        public static new T Instantiate<T>(T entity, Vector3 position, Quaternion rotation) where T : Entity
        {
            T obj = Object.Instantiate(entity, position, rotation);
            ObjectSorter.SubscribeEntity(obj);
            return obj;
        }
        public void Destroy(Entity entity)
        {
            ObjectSorter.UnSubscribeEntity(entity);
            Destroy(entity.gameObject);
        }
    }
}

