using UnityEngine;

public class PlayerAnime : MonoBehaviour
{
    private Player player;
    private Animator animator;
    
    void Start()
    {
        player = GetComponent<Player>();
        this.animator = GetComponent<Animator>();
    }

    void Update()
    {
         
        if (player._direction.sqrMagnitude > 0){             
            this.animator.SetInteger("Transition", 1);
        }else{
            this.animator.SetInteger("Transition", 0);
        }
        
        if (player._direction.x > 0){             
          transform.eulerAngles = new Vector2(0,0);
        }else if (player._direction.x < 0){
            transform.eulerAngles = new Vector2(0, 180);
        }

    }
}