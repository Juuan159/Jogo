using UnityEngine;

public class InimigoMov : MonoBehaviour
{
    public enum EnemyState { Idle, Chasing, Attacking }
    [Header("Estados")]
    public EnemyState currentState;

    [Header("Configurações de Movimento")]
    public float speed;
    public float attackRange = 1.2f; 

    [Header("Configurações de Cooldown")]
    public float attackCooldown = 2f; 
    private float attackCooldownTimer;

    [Header("Detecção do Jogador")]
    public float playerDetectDistance = 5f;
    public Transform detectionPoint;
    public LayerMask playerLayer;

    private Rigidbody2D rb;
    private Animator animator;
    private Transform player; 

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        currentState = EnemyState.Idle;

        int ladoAleatorio = Random.Range(0, 2);

        if (ladoAleatorio == 0)
        {
            transform.localScale = new Vector3(1, 1, 1);
        }
        else
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }
    }

    void Update()
    {
        CheckForPlayer();

        if (attackCooldownTimer > 0)
        {
            attackCooldownTimer -= Time.deltaTime;
        }

        if (currentState == EnemyState.Chasing)
        {
            Chase();
        }
        else if (currentState == EnemyState.Attacking || currentState == EnemyState.Idle)
        {
            rb.linearVelocity = Vector2.zero;
        }
    }

    void CheckForPlayer()
    {
        Collider2D[] hits = Physics2D.OverlapCircleAll(detectionPoint.position, playerDetectDistance, playerLayer);

        if (hits.Length > 0)
        {
            player = hits[0].transform; // Pega o transform do primeiro objeto detectado no array

            float distanceToPlayer = Vector2.Distance(transform.position, player.position);

            if (distanceToPlayer <= attackRange && attackCooldownTimer <= 0)
            {
                attackCooldownTimer = attackCooldown; 
                ChangeState(EnemyState.Attacking);
            }
            else if (distanceToPlayer > attackRange && currentState != EnemyState.Attacking)
            {
                ChangeState(EnemyState.Chasing);
            }
        }
        else
        {
            rb.linearVelocity = Vector2.zero;
            ChangeState(EnemyState.Idle);
        }
    }

    void Chase()
    {
        if (player == null) return;

        Vector2 direction = (player.position - transform.position).normalized;
        rb.linearVelocity = direction * speed;

        if (direction.x > 0)
            transform.localScale = new Vector3(1, 1, 1);
        else if (direction.x < 0)
            transform.localScale = new Vector3(-1, 1, 1);
    }

    public void ChangeState(EnemyState newState)
    {
        currentState = newState;

        if (currentState == EnemyState.Chasing)
        {
            animator.SetBool("isChasing", true);
        }
        else if (currentState == EnemyState.Idle)
        {
            animator.SetBool("isChasing", false);
        }
        else if (currentState == EnemyState.Attacking)
        {
            animator.SetBool("isChasing", false);
            animator.SetTrigger("attack"); 
        }
    }

    public void AttackAnimationEnded()
    {
        ChangeState(EnemyState.Idle);
    }

    private void OnDrawGizmosSelected()
    {
        if (detectionPoint == null) return;
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(detectionPoint.position, playerDetectDistance);
    }
}
