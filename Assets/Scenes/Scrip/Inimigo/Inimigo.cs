using UnityEngine;

public class Inimigo : MonoBehaviour
{
    [Header("Configurações do Ataque")]
    public int damage = 10; 
    public float weaponRange = 1f;
    public float knockbackForce;
    public float stunTime;
    public Transform attackPoint; 
    public LayerMask playerLayer;

    public void Attack()
    {
        Collider2D[] hits = Physics2D.OverlapCircleAll(attackPoint.position, weaponRange, playerLayer);

        if (hits.Length > 0)
        {
            PlayerHP playerHealth = hits[0].GetComponent<PlayerHP>();
            Player playerKnock= hits[0].GetComponent<Player>();
            if (playerHealth != null)
            {
                playerHealth.ChanngeHealth(-damage);
                playerKnock.Knockback(transform, knockbackForce, stunTime);
            }
        }
    }
}
