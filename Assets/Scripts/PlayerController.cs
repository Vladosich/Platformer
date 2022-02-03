using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float horizontalInput;
    private readonly float speed = 5f;
    private readonly float jumpForce = 5f;


    private Rigidbody2D playerRigidbody;

    private void Start()
    {
        playerRigidbody = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (Input.GetButtonDown("Jump"))
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
    }
}
