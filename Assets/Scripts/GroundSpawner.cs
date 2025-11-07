using UnityEngine;

public class GroundSpawner : MonoBehaviour
{
    public GameObject groundPrefab;
    public int numberOfTiles = 10;
    public Transform player;

    private GameObject[] tiles;
    private int nextTileIndex = 0;
    private float spawnX;
    private float tileWidth;

    void Start()
    {
        tileWidth = groundPrefab.GetComponent<SpriteRenderer>().bounds.size.x;
        tiles = new GameObject[numberOfTiles];

        for (int i = 0; i < numberOfTiles; i++)
        {
            tiles[i] = Instantiate(groundPrefab, new Vector3(i * tileWidth, -3f, 0f), Quaternion.identity);
        }

        spawnX = numberOfTiles * tileWidth;
    }

    void LateUpdate()
    {
        if (player == null) return;

        if (player.position.x > tiles[nextTileIndex].transform.position.x + tileWidth)
        {
            // Округляем координату, чтобы убрать дёргание
            Vector3 newPos = new Vector3(Mathf.Round(spawnX * 100f) / 100f, -3f, 0f);
            tiles[nextTileIndex].transform.position = newPos;

            spawnX += tileWidth;
            nextTileIndex = (nextTileIndex + 1) % tiles.Length;
        }
    }
}