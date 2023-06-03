using UnityEngine;
using UnityEngine.UI;

namespace ProcketZone2.UI
{
    public static class UIBuilder
    {
        public static Canvas BuildCanvas()
        {
            GameObject obj = new GameObject();
            obj.name = "Canvas";

            Canvas canvas = obj.AddComponent<Canvas>();
            canvas.renderMode = RenderMode.ScreenSpaceCamera;
            canvas.worldCamera = Camera.main;

            CanvasScaler scaler = obj.AddComponent<CanvasScaler>();
            scaler.uiScaleMode = CanvasScaler.ScaleMode.ScaleWithScreenSize;
            scaler.referenceResolution = new Vector2(1920, 1080);
            obj.AddComponent<GraphicRaycaster>();
            return canvas;
        }
    }
}