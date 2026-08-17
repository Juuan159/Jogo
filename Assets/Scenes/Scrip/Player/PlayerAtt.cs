using Unity.VisualScripting;
using UnityEngine;

public class PlayerAtt : MonoBehaviour
{
    public Animator anim;
    public Transform attackPoint;
    public float weaponRange = 1;
    public LayerMask inimigoLayer;
    public int damage = 10;
    public float cooldown = 2;
    public float timer;
    public float knockbackForce = 50;
    public float stuntime = .3f;
    public float knockbacktime = .15f;

    public void Update()
    {
        if(timer > 0)
        timer -= Time.deltaTime; 
    }

    public void Attack()
    {
        if(timer <= 0)
        {
            anim.SetBool("isAttacking", true);
            
            timer = cooldown;
        }
    }

    public void DealDamage()
    {
        Collider2D[] inimigos = Physics2D.OverlapCircleAll(attackPoint.position, weaponRange, inimigoLayer);
        if(inimigos.Length > 0)
        {
            inimigos[0].GetComponent<InimigoHP>().ChanngeHealth(-damage);
            inimigos[0].GetComponent<InimigoKN>().Knockback(transform,knockbackForce, knockbacktime,stuntime);
        }
    }
        
    public void FinishAttacking()
    {
        anim.SetBool("isAttacking", false);
        
    }
    public void OnDrawGizmosSelected()
    {
        if (attackPoint != null)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(attackPoint.position, weaponRange);   
        }
    }
}
