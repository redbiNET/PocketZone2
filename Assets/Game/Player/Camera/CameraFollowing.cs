using UnityEngine;

public class CameraFollowing : MonoBehaviour
{
    [SerializeField] private Transform _target;
    [SerializeField] private float _speed;

    [SerializeField] private Vector2 _size;
    [SerializeField] private Vector2 _offset;
    [SerializeField] private Vector2 _cameraSize => CalculateCameraSize();

    private Vector2 CalculateCameraSize()
    {
        Vector2 size = new Vector2
            (
                (float)Screen.width / (float)Screen.height * Camera.main.orthographicSize,
                Camera.main.orthographicSize
            );
        return size;
    }
    private void Update()
    {
        Vector3 from = transform.position;
        Vector3 to = _target.position;
        to.z = from.z;
        Vector3 position = Vector3.Lerp(from, to, _speed * Time.deltaTime);
        Vector2 size = _size - _cameraSize;
        position = new Vector3
            (
                Mathf.Clamp(position.x, -size.x + _offset.x, size.x + _offset.x),
                Mathf.Clamp(position.y, -size.y + _offset.y, size.y + _offset.y),
                position.z
            );
        transform.position = position;
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;

        Gizmos.DrawWireCube(Vector2.zero + _offset, _size*2);
    }
}
