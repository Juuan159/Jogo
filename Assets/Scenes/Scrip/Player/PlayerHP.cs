using System.Collections;
using TMPro;
using UnityEngine;

[RequireComponent(typeof(Player))]
public class PlayerHP : MonoBehaviour
{
    private Player player;
    [SerializeField] TMP_Text healthText;
    [SerializeField] int maxtHelt;
    [SerializeField] Animator healthTextAnimator;

    [SerializeField] private SpriteRenderer playerSprite;
    private Color corOriginal;
    private Coroutine danoCoroutine;

    private Color vermelho = new Color(1f, 0.3f, 0.3f, 1f);

    void Start()
    {
        player = GetComponent<Player>();
        maxtHelt = player._health;
        healthText.text = "HP: " + player._health + " / " + maxtHelt;
        corOriginal = playerSprite.color;
    }
    
    public void ChanngeHealth(int amount)
    {
        player._health += amount;
        
        if (player._health >= 0)
        {
            healthText.text = "HP: " + player._health + " / " + maxtHelt;
        }
        else
        {
            healthText.text = "HP: 0 / " + maxtHelt;
        }
        
        healthTextAnimator.Play("HP_Text Animation");

        if (amount < 0 && player._health > 0)
        {
            if (danoCoroutine != null) StopCoroutine(danoCoroutine);
            danoCoroutine = StartCoroutine(EfeitoVermelho(0.3f));
        }

        if (player._health <= 0)
        {
            player.gameObject.SetActive(false);
        }
    }

    private IEnumerator EfeitoVermelho(float duracao)
    {
        playerSprite.color = vermelho;
        yield return new WaitForSeconds(duracao);
        playerSprite.color = corOriginal;
    }
}
