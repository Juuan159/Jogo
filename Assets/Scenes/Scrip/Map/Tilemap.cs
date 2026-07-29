using UnityEngine;

public class Tilemap : MonoBehaviour
{
    public Collider2D[] mountainColliders;
    public Collider2D[] bordColliders;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") || collision.transform.root.CompareTag("Player"))
        {
            foreach (Collider2D mountain in mountainColliders)
            {
                if (mountain != null)
                {
                    mountain.enabled = false;
                }
            }

            if (collision.TryGetComponent<SpriteRenderer>(out SpriteRenderer playerSprite))
            {
                playerSprite.sortingOrder = 10;
            }

            foreach (Collider2D bord in bordColliders)
            {
                if (bord != null)
                {
                    bord.enabled = true;
                }
            }
        }
    }
}
