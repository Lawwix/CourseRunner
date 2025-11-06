using UnityEngine;

public class GroundRepeater : MonoBehaviour
{
    public Transform player;
    public float repeatWidth = 20f;

    private Vector3 startPosition;

    void Start()
    {
        startPosition = transform.position;
    }

    void Update()
    {
        // Когда игрок уйдёт далеко — перенести землю вперёд
        if (player.position.x - transform.position.x > repeatWidth)
        {
            transform.position = new Vector3(player.position.x, transform.position.y, transform.position.z);
        }
    }
}