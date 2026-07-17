using UnityEngine;
// OBRIGATÓRIO: Adiciona a biblioteca do novo sistema de input
using UnityEngine.InputSystem; 

public class Player : MonoBehaviour
{
    public float velocidade = 5.0f;
    private Rigidbody2D rb;
    private Vector2 direcao;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        // Zera a gravidade (gravityScale = 0f) como você lembrou!
        rb.gravityScale = 0f;
        
        // Evita que o personagem rode ao colidir
        rb.freezeRotation = true;
    }

    void Update()
    {
        // Reseta a direção a cada frame
        direcao = Vector2.zero;

        // Pega o teclado atual conectado
        Keyboard teclado = Keyboard.current;

        // Se o teclado existir, faz a checagem equivalente ao GetKey antigo
        if (teclado != null)
        {
            // .isPressed funciona exatamente como o GetKey mantido pressionado
            if (teclado.wKey.isPressed) direcao.y += 1;
            if (teclado.sKey.isPressed) direcao.y -= 1;
            if (teclado.aKey.isPressed) direcao.x -= 1;
            if (teclado.dKey.isPressed) direcao.x += 1;
        }

        // Normaliza para não correr mais rápido na diagonal
        direcao = direcao.normalized;
    }

    void FixedUpdate()
    {
        // Aplica o movimento de forma sincronizada com o motor físico
        rb.linearVelocity = direcao * velocidade;
    }
}
