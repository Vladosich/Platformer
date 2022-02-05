using UnityEngine;

public class MovingEnemy : Enemy
{
    [SerializeField] private Vector2 direction;

    private void FixedUpdate()
    {
        Walk();
    }

    protected override void OnCollisionEnter2D(Collision2D collision)
    {
        base.OnCollisionEnter2D(collision);
    }

    private void Walk()
    {
        transform.Translate(direction);
    }
}
