using UnityEngine;

public class HeroMoveScript : MonoBehaviour
{

    public Rigidbody2D HeroBody;
    public float moveSpeed = 5f;

    Vector2 movement;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()//inputs
    {
        //while (Input.GetKeyDown(KeyCode.UpArrow) == true)
        //{
        //    HeroBody.linearVelocity = Vector2.up * flapStrength;//shorthand for Vector2(0,1), how the game decides what direction your traveling in, *10 for more power
        //}
        movement.x = Input.GetAxisRaw("Horizontal");//Should be both ad and arrows
        movement.y = Input.GetAxisRaw("Vertical");//Should be both ws and arrows
      //  HeroBody.linearVelocity = 0;
    }

    void FixedUpdate()//Does not depend on framerate, movement
    {
        HeroBody.MovePosition(HeroBody.position + movement*moveSpeed*Time.fixedDeltaTime);//current+input
    }
}
