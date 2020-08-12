using UnityEngine;

public class AlienController : MonoBehaviour
{
    [SerializeField] private float speed = 0.0f;
    private float horizontalInput = 0.0f;
    private float verticalInput = 0.0f;
    private Vector3 movementVector = Vector3.zero;
    private Vector2 jumpVector = Vector2.zero;
    [SerializeField] private float jumpForce = 0.0f;
    private Rigidbody2D rb = default;
    private bool isOnGround = false;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");

        movementVector.x = horizontalInput;

        transform.position += (movementVector * speed) * Time.deltaTime;

        if (verticalInput >= 0.5f && isOnGround)
        {
            isOnGround = false;
            jumpVector.y = jumpForce;
            rb.AddForce(jumpVector, ForceMode2D.Impulse);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            isOnGround = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            isOnGround = false;
        }
    }
}
