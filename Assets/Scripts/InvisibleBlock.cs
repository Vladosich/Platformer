using UnityEngine;

public class InvisibleBlock : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            GetComponentInChildren<SpriteRenderer>().enabled = true;
        }
    }
}
