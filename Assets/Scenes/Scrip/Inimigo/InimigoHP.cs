using System.Collections;
using TMPro;
using UnityEngine;

public class InimigoHP : MonoBehaviour
{
    private Inimigo inimigo;
    public int maxtHelt;
    private Color corOriginal;
    private Coroutine danoCoroutine;
    public SpriteRenderer InimigoSprite;

    private Color vermelho = new Color(1f, 0.3f, 0.3f, 1f);

    void Start()
    {
        inimigo = GetComponent<Inimigo>();
        inimigo._health = maxtHelt;
        corOriginal = InimigoSprite.color;
    }
    
    public void ChanngeHealth(int amount)
    {
        inimigo._health += amount;

        if(inimigo._health > maxtHelt)
        {
            inimigo._health = maxtHelt;
        }
        else if (inimigo._health <= 0)
        {
            inimigo.gameObject.SetActive(false);
        }
                
        if (amount < 0 && inimigo._health > 0)
        {
            if (danoCoroutine != null) StopCoroutine(danoCoroutine);
            danoCoroutine = StartCoroutine(EfeitoVermelho(0.3f));
        }

        if (inimigo._health <= 0)
        {
            inimigo.gameObject.SetActive(false);
        }
    }

    private IEnumerator EfeitoVermelho(float duracao)
    {
        InimigoSprite.color = vermelho;
        yield return new WaitForSeconds(duracao);
        InimigoSprite.color = corOriginal;
    }
}
