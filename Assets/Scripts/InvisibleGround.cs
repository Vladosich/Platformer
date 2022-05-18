using UnityEngine;

public class InvisibleGround : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            GetComponentInChildren<SpriteRenderer>().enabled = true;
        }
    }
}
