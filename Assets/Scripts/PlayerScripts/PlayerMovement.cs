using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        print("PlayerMovement script has started.");
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 movement = new Vector2(0, 0);
        
        if (Keyboard.current.wKey.isPressed) movement.y += 1;
        if (Keyboard.current.sKey.isPressed) movement.y -= 1;
        if (Keyboard.current.aKey.isPressed) movement.x -= 1;
        if (Keyboard.current.dKey.isPressed) movement.x += 1;
        
        movement.Normalize();
        transform.Translate(movement * speed * Time.deltaTime);
        
    }
}
