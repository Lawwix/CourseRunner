using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    // Игрок, за которым будет следить камера
    public Transform player;

    // Насколько плавно камера движется
    public float smoothSpeed = 0.125f;

    // Смещение камеры по оси X и Y (чтобы не была прямо по центру)
    public Vector3 offset = new Vector3(0, 0, -10f);

    void LateUpdate()
    {
        if (player == null) return; // защита от ошибок

        // Целевая позиция камеры
        Vector3 desiredPosition = player.position + offset;

        // Округляем, чтобы убрать микроподёргивания
        desiredPosition.x = Mathf.Round(desiredPosition.x * 100f) / 100f;
        desiredPosition.y = Mathf.Round(desiredPosition.y * 100f) / 100f;

        // Плавное движение камеры
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);

        transform.position = smoothedPosition;
    }
}