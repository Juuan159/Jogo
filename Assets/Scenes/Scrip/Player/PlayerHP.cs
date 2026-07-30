using TMPro;
using UnityEngine;
[RequireComponent(typeof(Player))]
public class PlayerHP : MonoBehaviour
{
    private Player player;
    [SerializeField] TMP_Text healthText;
    [SerializeField] int maxtHelt;
    [SerializeField] Animator healthTextAnimator;

    void Start()
    {
        player = GetComponent<Player>();
        maxtHelt = player._health;
        healthText.text = "HP: "+ player._health +" / "+maxtHelt;
    }
    
    public void ChanngeHealth(int amount)
    {
        player._health +=amount;
        healthText.text = "HP: "+ player._health +" / "+maxtHelt;
        healthTextAnimator.Play("HP_Text Animation");
        if(player._health <= 0)
        {
            player.gameObject.SetActive(false);
        }
    }
}