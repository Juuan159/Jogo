using System;
using UnityEngine;

public class Inimigo : MonoBehaviour
{
    [SerializeField] private int damage = -10;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            PlayerHP playerHP = collision.gameObject.GetComponent<PlayerHP>();

                playerHP.ChanngeHealth(damage);
        }
    }
}
