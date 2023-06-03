using UnityEngine;

namespace ProcketZone2.UI
{
    [RequireComponent(typeof(RectTransform))]
    public class UIEntity : MonoBehaviour
    {
        public RectTransform Rect { get; private set; }

        private void Init()
        {
            Rect = GetComponent<RectTransform>();
        }
        public static new T Instantiate<T>(T entity) where T : UIEntity
        {
            Canvas canvas = FindObjectOfType<Canvas>();
            if(canvas == null)
            {
                canvas = UIBuilder.BuildCanvas();
            }
            T obj = Object.Instantiate(entity, canvas.transform);
            obj.Init();
            return obj;
        }
    }
    
}
