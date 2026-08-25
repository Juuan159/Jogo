using System.Numerics;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerAtt : MonoBehaviour
{
    
    public Transform attackPoint;
    public StatusUI statusUI;
    private Transform Player;
    
    public LayerMask inimigoLayer;

    public Animator anim;
     
    public float cooldown = 2;
    public float timer;
    private Inimigo inimigo;

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
        statusUI.UpdateDamage();

        Collider2D[] inimigos = Physics2D.OverlapCircleAll(attackPoint.position, StatusManeger.Instance.weaponRange, inimigoLayer);

        if(inimigos.Length > 0)
        {   
            //StatusManeger.Instance.damage += 1; SEDE DE SANGUE N SEI SE SERA UTIL
            inimigos[0].GetComponent<InimigoHP>().ChanngeHealth(-StatusManeger.Instance.damage);
            inimigos[0].GetComponent<InimigoKN>().Knockback(transform,StatusManeger.Instance.knockbackForce, StatusManeger.Instance.knockbacktime,StatusManeger.Instance.stuntime);
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
            Gizmos.DrawWireSphere(attackPoint.position, StatusManeger.Instance.weaponRange);   
        }
    }
}
