using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float horizontalInput;
    private readonly float speed = 5f;
    private readonly float jumpForce = 5f;

    private bool isGrounded;

    private Rigidbody2D playerRigidbody;

    public bool IsGrounded { get { return isGrounded; } }

    private void Start()
    {
        playerRigidbody = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            Jump();
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

    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        isGrounded = collision.gameObject.CompareTag("Ground");
    }

}
