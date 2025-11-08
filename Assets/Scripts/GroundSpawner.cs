using UnityEngine;

public class GroundSpawner : MonoBehaviour
{
    [Header("Настройки пола")]
    public GameObject groundPrefab;   // Префаб тайла пола
    public int numberOfTiles = 6;     // Количество тайлов на сцене одновременно

    [Header("Игрок")]
    public Transform player;          // Игрок

    private GameObject[] tiles;       // Тайлы на сцене
    private float tileWidth;          // Ширина тайла
    private int nextTileIndex = 0;    // Следующий тайл для перестановки
    private float spawnX;             // Позиция для следующего тайла

    void Start()
    {
        if (groundPrefab == null || player == null)
        {
            Debug.LogError("GroundSpawner: Префаб пола или игрок не назначен!");
            return;
        }

        // Получаем точную ширину тайла по коллайдеру
        tileWidth = groundPrefab.GetComponent<BoxCollider2D>().size.x * groundPrefab.transform.localScale.x;

        // Создаём массив тайлов
        tiles = new GameObject[numberOfTiles];

        // Спавним тайлы на сцене
        for (int i = 0; i < numberOfTiles; i++)
        {
            float xPos = i * tileWidth;
            float yPos = -3f; // Высота пола, подставь нужное значение
            tiles[i] = Instantiate(groundPrefab, new Vector3(xPos, yPos, 0f), Quaternion.identity);
        }

        spawnX = numberOfTiles * tileWidth;
    }

    void Update()
    {
        if (player == null) return;

        // Если игрок пересёк центр тайла, переставляем тайл вперёд
        if (player.position.x > tiles[nextTileIndex].transform.position.x + tileWidth / 2f)
        {
            tiles[nextTileIndex].transform.position = new Vector3(spawnX, tiles[nextTileIndex].transform.position.y, 0f);
            spawnX += tileWidth;
            nextTileIndex = (nextTileIndex + 1) % tiles.Length;
        }
    }
}

//using UnityEngine;

//public class GroundSpawner : MonoBehaviour
//{
//    public GameObject groundPrefab;
//    public int numberOfTiles = 10;
//    public Transform player;

//    private GameObject[] tiles;
//    private int nextTileIndex = 0;
//    private float spawnX;
//    private float tileWidth;

//    void Start()
//    {
//        tileWidth = groundPrefab.GetComponent<SpriteRenderer>().bounds.size.x;
//        tiles = new GameObject[numberOfTiles];

//        for (int i = 0; i < numberOfTiles; i++)
//        {
//            tiles[i] = Instantiate(groundPrefab, new Vector3(i * tileWidth, -3f, 0f), Quaternion.identity);
//        }

//        spawnX = numberOfTiles * tileWidth;
//    }

//    void LateUpdate()
//    {
//        if (player == null) return;

//        if (player.position.x > tiles[nextTileIndex].transform.position.x + tileWidth)
//        {
//            // Округляем координату, чтобы убрать дёргание
//            Vector3 newPos = new Vector3(Mathf.Round(spawnX * 100f) / 100f, -3f, 0f);
//            tiles[nextTileIndex].transform.position = newPos;

//            spawnX += tileWidth;
//            nextTileIndex = (nextTileIndex + 1) % tiles.Length;
//        }
//    }
//}