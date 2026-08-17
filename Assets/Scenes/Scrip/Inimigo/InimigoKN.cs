using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InimigoKN : MonoBehaviour
{
    private Rigidbody2D rig;
    private InimigoMov InimigoMov;

    private void Start()
    {
        rig = GetComponent<Rigidbody2D>();
        InimigoMov = GetComponent<InimigoMov>();
    }
    public void Knockback(Transform playerTransform,float knockbackForce, float knockbacktime,float stunTime)
    {
       InimigoMov.ChangeState(InimigoMov.EnemyState.Knockback);
       StartCoroutine(StunTimer(knockbacktime,stunTime));
       Vector2 diretion = (transform.position - playerTransform.position).normalized;
       rig.linearVelocity = diretion * knockbackForce;
       Debug.Log("Knockback Apply");
    }

    IEnumerator StunTimer(float knockbacktime,float stun)
    {
        yield return new WaitForSeconds(knockbacktime);
        rig.linearVelocity = Vector2.zero;
        yield return new WaitForSeconds(stun);    
        InimigoMov.ChangeState(InimigoMov.EnemyState.Idle);
    }
}
