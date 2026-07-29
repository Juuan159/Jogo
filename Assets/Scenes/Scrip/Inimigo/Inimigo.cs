using System;
using UnityEngine;

public class Inimigo : MonoBehaviour
{
    [SerializeField] private int damage = -10;


    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log($"Colidiu com: {collision.gameObject.name}");
        collision.gameObject.GetComponent<PlayerHP>().ChanngeHealth(damage);
    }
    void Start()
    {
        
    }

    void Update()
    {
        
    }
}
