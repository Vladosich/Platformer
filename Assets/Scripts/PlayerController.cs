using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float horizontalInput;
    private readonly float speed = 5f;
    private readonly float jumpForce = 5f;
    private readonly float groundCheckRadius = 0.05f;

    private bool isGrounded;
    private bool facingRight = true;

    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask whatIsGround;
    private Rigidbody2D playerRigidbody;

    public bool IsGrounded { get { return isGrounded; } }

    private void Start()
    {
        playerRigidbody = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, whatIsGround);

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            Jump();
        }

        if (facingRight && horizontalInput < 0)
        {
            Flip();
        }
        else if (!facingRight && horizontalInput > 0)
        {
            Flip();
        }
    }

    private void FixedUpdate()
    {
        Run();
    }

    private void Run()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        playerRigidbody.velocity = new Vector2(horizontalInput * speed, playerRigidbody.velocity.y);
    }

    private void Jump()
    {
        playerRigidbody.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        isGrounded = false;
    }

    private void Flip()
    {
        facingRight = !facingRight;
        Vector2 scaler = transform.localScale;
        scaler.x *= -1;
        transform.localScale = scaler;
    }
}
