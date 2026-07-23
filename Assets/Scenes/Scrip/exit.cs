using UnityEngine;

public class exit : MonoBehaviour
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
                    mountain.enabled = true;
                }
            }

            if (collision.TryGetComponent<SpriteRenderer>(out SpriteRenderer playerSprite))
            {
                playerSprite.sortingOrder = 5;
            }

            foreach (Collider2D bord in bordColliders)
            {
                if (bord != null)
                {
                    bord.enabled = false;
                }
            }



            
        }
    }
}

