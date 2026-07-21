using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    private Player player;
    private Animator animator;
    private SpriteRenderer spriteRenderer;

    void Start()
    {
        player = GetComponent<Player>();
        this.animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        if (player == null) return;

        if (player._diretion.sqrMagnitude > 0)
        {
            this.animator.SetInteger("Transition", 1);
        }
        else
        {
            this.animator.SetInteger("Transition", 0);
        }
        
        if (player._diretion.x > 0) 
        {
            spriteRenderer.flipX = false;
        }
        else if (player._diretion.x < 0) 
        {
            spriteRenderer.flipX = true;
        }
    }
}
