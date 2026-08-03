using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Animator))]
public class InimigoMov : MonoBehaviour
{
    
    [SerializeField] private Rigidbody2D rb; 
    [SerializeField] private Player player;
    [SerializeField] private float speed;
    [SerializeField] private EnemyState stateEnemy;
    [SerializeField] private int face;
    [SerializeField] private bool precisaVirar;
    [SerializeField] private bool isVisible =false;
    
    private Animator animacao;
    private static readonly int PlayerHash = Animator.StringToHash("Player");

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        animacao = GetComponent<Animator>();
        
        speed = 3.0f;
        face = 1;
        precisaVirar = false;
    }
    void Start()
    {
        
        ChanceState(EnemyState.isIdle);
    }
  
    void FixedUpdate()
    {   

        if(isVisible==true){
            precisaVirar = Mathf.Sign(player.transform.position.x - transform.position.x) != face;
            if(precisaVirar)
            {
                Flip();
            }
            Vector2 direction = (player.transform.position - transform.position).normalized;
            rb.linearVelocity = direction*speed;
        }
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        
        if(other.CompareTag("Player"))
        {   
            if(player==null)
                player = other.GetComponent<Player>();
            isVisible = true;
            ChanceState(EnemyState.isMoving);
        } 
             
    }
    void OnTriggerExit2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
             isVisible = false;
             rb.linearVelocity = Vector2.zero;
             ChanceState(EnemyState.isIdle);
        }
            
    }
    void Flip()
    {
        face*=-1;
        transform.localScale =  new Vector3(transform.localScale.x * -1,transform.localScale.y,transform.localScale.z);
    }

    void ChanceState(EnemyState newState)
    {
        if (stateEnemy == newState) return;
        
        if (newState == EnemyState.isIdle){
          animacao.SetBool("isMoving",false);
          animacao.SetBool("isIdle",true);
          
          stateEnemy = newState;
        }
        else
        {
             animacao.SetBool("isIdle",false);
             animacao.SetBool("isMoving",true);
             stateEnemy = newState;
        }
    }

}


public enum EnemyState{
    isIdle,
    isMoving,
    Attack,

}
