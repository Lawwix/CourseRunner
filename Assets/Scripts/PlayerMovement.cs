using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5f;        // �������� �������� �����
    public float jumpForce = 10f;   // ���� ������
    private Rigidbody2D rb;
    private bool isGrounded = true;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // �������� �����
        rb.linearVelocity = new Vector2(speed, rb.linearVelocity.y);

        // ������
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
            isGrounded = false;
        }
    }

    // ��������, ��� ����� �� �����
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }
}