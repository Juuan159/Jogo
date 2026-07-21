using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    public int life = 40;
    public float speed = 5f;
    
    private Vector2 diretion;
    public Vector2 _diretion
    {
        get { return this.diretion; }
        set { this.diretion = value; }
    }
    
    void Start()
    {
        Debug.Log("Inicio da Cena");
    }

    void Update()
    {
        _diretion = Mover(); 
        Debug.Log($"Inicio da Cena {_diretion}");
        transform.position += (Vector3)_diretion * (speed * Time.deltaTime);     
    }

    Vector2 Mover()
    {
        Vector2 currentDirection = Vector2.zero;
        
        if (Keyboard.current.wKey.isPressed || Keyboard.current.upArrowKey.isPressed) 
            currentDirection.y = 1f;
        if (Keyboard.current.sKey.isPressed || Keyboard.current.downArrowKey.isPressed) 
            currentDirection.y = -1f;
        if (Keyboard.current.aKey.isPressed || Keyboard.current.leftArrowKey.isPressed) 
            currentDirection.x = -1f;
        if (Keyboard.current.dKey.isPressed || Keyboard.current.rightArrowKey.isPressed) 
            currentDirection.x = 1f;
            
        return currentDirection.normalized;
    }
}
