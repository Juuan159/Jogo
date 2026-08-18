using UnityEngine;

public class StatusManeger : MonoBehaviour
{
    public static  StatusManeger Instance;

    [Header("Combat Status")]
    public int damage;
    public float weaponRange;
    public float knockbackForce;
    public float knockbacktime;
    public float stuntime;

    [Header("Movement Status")]
    public int speed;

    [Header("Health Staus")]
    public int maxtHelt;
    public int currentHealth;

    public void Awake()
    {
        if(Instance == null)
        Instance = this;
        else
        Destroy(gameObject);
    }

}
