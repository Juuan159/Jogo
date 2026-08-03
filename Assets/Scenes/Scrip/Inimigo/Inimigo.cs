using System;
using UnityEngine;

public class Inimigo : MonoBehaviour
{
    [SerializeField] private int damage = -10;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log($"Colidiu com: {collision.gameObject.name}");

        if (collision.gameObject.CompareTag("Player"))
        {
            PlayerHP playerHP = collision.gameObject.GetComponent<PlayerHP>();

            if (playerHP != null)
            {
                playerHP.ChanngeHealth(damage);
            }
            else
            {
                Debug.LogWarning($"Colidiu com o Player, mas o script 'PlayerHP' não foi encontrado no objeto!");
            }
        }
    }
}
