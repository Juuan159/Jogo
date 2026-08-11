using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    [SerializeField] private int health = 100;
    public float speed = 5f;
    private Vector2 direction;
    private Rigidbody2D rig; 
    private bool isKnockedBack;
    

    public Vector2 _direction
    {
        get { return this.direction;} 
        set { this.direction = value;} 
    }

    void Start()
    {
        Debug.Log("Inicio da Cena");
        rig = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
           
    }
    
    public void OnMove(InputValue value)
    {
        direction = value.Get<Vector2>();
    }
    
    Vector3 Mover(Vector2 direction)
    {
        this.direction = Vector2.zero;
        if (Keyboard.current.wKey.isPressed || Keyboard.current.upArrowKey.isPressed) 
            this.direction.y = 1f;
        if (Keyboard.current.sKey.isPressed || Keyboard.current.downArrowKey.isPressed) 
            this.direction.y = -1f;
        if (Keyboard.current.aKey.isPressed || Keyboard.current.leftArrowKey.isPressed) 
            this.direction.x = -1f;
        if (Keyboard.current.dKey.isPressed || Keyboard.current.rightArrowKey.isPressed) 
            this.direction.x = 1f;
        return (Vector3)this.direction.normalized;
    }

    private void FixedUpdate()
    {
        if(isKnockedBack == false)
        rig.linearVelocity =Mover(direction) * (speed);           
    }

    public void Knockback(Transform Inimigo, float force, float stunTime)
    {
        isKnockedBack = true;
        Vector2 direction = (transform.position - Inimigo.position).normalized;
        rig.linearVelocity = direction * force;
        if(_health > 0)
        StartCoroutine(KnockbackCounter(stunTime));
    }

    IEnumerator KnockbackCounter(float stun)
    {
        yield return new WaitForSeconds(stun);
        rig.linearVelocity = Vector2.zero;
        isKnockedBack = false;
    }

    public int _health
    {
        get {return this.health;}
        set {this.health = value;}
    }
}