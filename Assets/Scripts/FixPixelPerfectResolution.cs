using UnityEngine;

[ExecuteAlways]
public class FixPixelPerfectResolution : MonoBehaviour
{
    void Update()
    {
        int width = Screen.width;
        int height = Screen.height;

        // Проверяем, нечётное ли разрешение
        if (width % 2 != 0 || height % 2 != 0)
        {
            // Принудительно уменьшаем до чётного числа
            Screen.SetResolution(width - (width % 2), height - (height % 2), false);
        }
    }
}