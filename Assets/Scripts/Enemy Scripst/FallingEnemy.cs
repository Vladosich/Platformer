using UnityEngine;

public class FallingEnemy : Enemy
{
    [SerializeField] private Vector2 direction;

    private bool isPlayerUnderObject;

    private void FixedUpdate()
    {
        if (isPlayerUnderObject)
        {
            Fall();
        }
    }

    protected override void OnCollisionEnter2D(Collision2D collision)
    {
        base.OnCollisionEnter2D(collision);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        isPlayerUnderObject = collision.gameObject.CompareTag("Player");
    }

    private void Fall()
    {
        transform.Translate(direction);
    }
}
