using UnityEngine;

public class GroundSpawner : MonoBehaviour
{
    public GameObject groundPrefab;
    public int numberOfTiles = 5;
    public float tileWidth = 10f;
    public Transform player;

    private GameObject[] tiles;
    private int nextTileIndex = 0;
    private float spawnZ = 0f;

    void Start()
    {
        tiles = new GameObject[numberOfTiles];
        for (int i = 0; i < numberOfTiles; i++)
        {
            tiles[i] = Instantiate(groundPrefab, new Vector3(i * tileWidth, -3, 0), Quaternion.identity);
        }
        spawnZ = numberOfTiles * tileWidth;
    }

    void Update()
    {
        // Проверяем, если игрок приближается к концу — переставляем старый сегмент вперёд
        if (player.position.x > tiles[nextTileIndex].transform.position.x + tileWidth)
        {
            tiles[nextTileIndex].transform.position = new Vector3(spawnZ, -3, 0);
            spawnZ += tileWidth;
            nextTileIndex = (nextTileIndex + 1) % numberOfTiles;
        }
    }
}