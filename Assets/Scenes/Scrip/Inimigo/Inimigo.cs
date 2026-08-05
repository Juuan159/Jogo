using UnityEngine;

public class Inimigo : MonoBehaviour
{
    [Header("Configurações do Ataque")]
    public int damage = 10; 
    public float weaponRange = 1f; 
    public Transform attackPoint; 
    public LayerMask playerLayer;

    public void Attack()
    {
        Collider2D[] hits = Physics2D.OverlapCircleAll(attackPoint.position, weaponRange, playerLayer);

        if (hits.Length > 0)
        {
            PlayerHP playerHealth = hits[0].GetComponent<PlayerHP>();
            if (playerHealth != null)
            {
                playerHealth.ChanngeHealth(-damage);
            }
        }
    }
}
