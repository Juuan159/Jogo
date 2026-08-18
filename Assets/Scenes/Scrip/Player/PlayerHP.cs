using System.Collections;
using TMPro;
using UnityEngine;

[RequireComponent(typeof(Player))]
public class PlayerHP : MonoBehaviour
{

    [SerializeField] TMP_Text healthText;
    [SerializeField] Animator healthTextAnimator;

    [SerializeField] private SpriteRenderer playerSprite;
    private Color corOriginal;
    private Coroutine danoCoroutine;

    private Color vermelho = new Color(1f, 0.3f, 0.3f, 1f);

    void Start()
    {
        StatusManeger.Instance.maxtHelt = StatusManeger.Instance.currentHealth;
        healthText.text = "HP: " + StatusManeger.Instance.currentHealth + " / " + StatusManeger.Instance.maxtHelt;
        corOriginal = playerSprite.color;
    }
    
    public void ChanngeHealth(int amount)
    {
        StatusManeger.Instance.currentHealth += amount;
        
        if (StatusManeger.Instance.currentHealth >= 0)
        {
            healthText.text = "HP: " + StatusManeger.Instance.currentHealth + " / " + StatusManeger.Instance.maxtHelt;
        }
        else
        {
            healthText.text = "HP: 0 / " + StatusManeger.Instance.maxtHelt;
        }
        
        healthTextAnimator.Play("HP_Text Animation");

        if (amount < 0 && StatusManeger.Instance.currentHealth > 0)
        {
            if (danoCoroutine != null) StopCoroutine(danoCoroutine);
            danoCoroutine = StartCoroutine(EfeitoVermelho(0.3f));
        }

        if (StatusManeger.Instance.currentHealth <= 0)
        {
            gameObject.SetActive(false);
        }
    }

    private IEnumerator EfeitoVermelho(float duracao)
    {
        playerSprite.color = vermelho;
        yield return new WaitForSeconds(duracao);
        playerSprite.color = corOriginal;
    }
}
