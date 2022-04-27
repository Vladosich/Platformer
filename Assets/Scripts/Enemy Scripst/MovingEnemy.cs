using UnityEngine;

public class MovingEnemy : Enemy
{
    private Vector2 direction = new Vector2(0.01f, 0f);

    private readonly float xDirection = 0.01f;

    private SpriteRenderer enemySprite;

    private void Start()
    {
        enemySprite = GetComponentInChildren<SpriteRenderer>();
    }

    private void FixedUpdate()
    {
        Walk();
    }

    protected override void OnCollisionEnter2D(Collision2D collision)
    {
        base.OnCollisionEnter2D(collision);

        if(!collision.gameObject.CompareTag("Player") && !collision.gameObject.CompareTag("Ground"))
        {
            if(direction.x > 0)
            {
                direction.x = -xDirection;
                Flip();
            }
            else
            {
                direction.x = xDirection;
                Flip();
            }
        }
    }

    private void Walk()
    {
        transform.Translate(direction);
    }

    private void Flip()
    {
        enemySprite.flipX = !enemySprite.flipX;
    }
}
