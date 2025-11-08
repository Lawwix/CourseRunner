using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 5f;
    public float jumpForce = 8f;
    private Rigidbody2D rb;
    private bool isGrounded;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    
    void Update()
    {
        Debug.Log("Update работает");
        // Постоянное движение вперёд
        rb.linearVelocity = new Vector2(speed, rb.linearVelocity.y);
        Debug.Log("Текущая скорость игрока: " + rb.linearVelocity.x);

        // Прыжок
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
            isGrounded = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Проверяем, коснулся ли игрок земли
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }
}

//using UnityEngine;

//[RequireComponent(typeof(Rigidbody2D))]
//public class PlayerController : MonoBehaviour
//{
//    public float moveSpeed = 5f;
//    public float jumpForce = 10f;
//    private Rigidbody2D rb;
//    private bool isGrounded = false;
//    private bool jumpPressed = false;

//    void Start()
//    {
//        rb = GetComponent<Rigidbody2D>();
//    }

//    void Update()
//    {
//        // Запоминаем нажатие пробела, чтобы не потерять его
//        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
//        {
//            jumpPressed = true;
//        }
//    }

//    void FixedUpdate()
//    {
//        // постоянное движение вперёд
//        rb.linearVelocity = new Vector2(moveSpeed, rb.linearVelocity.y);

//        // выполняем прыжок в физическом кадре
//        if (jumpPressed)
//        {
//            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
//            jumpPressed = false;
//        }
//    }

//    void OnCollisionEnter2D(Collision2D collision)
//    {
//        if (collision.gameObject.CompareTag("Ground"))
//            isGrounded = true;
//    }

//    void OnCollisionExit2D(Collision2D collision)
//    {
//        if (collision.gameObject.CompareTag("Ground"))
//            isGrounded = false;
//    }
//}

//using UnityEngine;

//public class PlayerController2D : MonoBehaviour
//{
//    public float moveSpeed = 5f;
//    public float jumpForce = 8f;
//    private Rigidbody2D rb;
//    private bool isGrounded = false;

//    void Start()
//    {
//        rb = GetComponent<Rigidbody2D>();
//    }

//    void Update()
//    {
//        // ���������� �������� ������
//        transform.Translate(Vector2.right * moveSpeed * Time.deltaTime);

//        // ������
//        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
//        {
//            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
//            isGrounded = false;
//        }
//    }

//    private void OnCollisionEnter2D(Collision2D collision)
//    {
//        if (collision.gameObject.CompareTag("Ground"))
//        {
//            isGrounded = true;
//        }
//    }

//    private void OnTriggerEnter2D(Collider2D collision)
//    {
//        if (collision.gameObject.CompareTag("Boundary"))
//        {
//            Debug.Log("Игрок упал за пределы карты!");
//            Time.timeScale = 0f; // останавливаем игру
//        }
//    }
//}