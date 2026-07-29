using UnityEngine;
[RequireComponent(typeof(Player))]
public class PlayerHP : MonoBehaviour
{
    private Player player;
    
    [SerializeField] int maxtHelt;
    void Start()
    {
        player = GetComponent<Player>();
        maxtHelt = player._health;
        //healttex.text = "HP: "+ player._health +" / "+maxtHelt;
    }
    
    public void ChanngeHealth(int amount)
    {
        player._health +=amount;
        //healttex.text = "HP: "+ player._health +" / "+maxtHelt;
        if(player._health <= 0)
        {
            player.gameObject.SetActive(false);
        }
    }
}