using UnityEngine;

public class HeroMoveScript : MonoBehaviour
{

    public Rigidbody2D HeroBody;
    public float moveSpeed = 5f;
    public bool paused = false;

    Vector2 movement;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()//inputs
    {
        if (paused == false)
        {
            movement.x = Input.GetAxisRaw("Horizontal");//Should be both ad and arrows
            movement.y = Input.GetAxisRaw("Vertical");//Should be both ws and arrows
        }
    }

    void FixedUpdate()//Does not depend on framerate, movement
    {
        HeroBody.MovePosition(HeroBody.position + movement*moveSpeed*Time.fixedDeltaTime);//current+input
    }

    public void setPaused(bool setBool)
    {
        paused = setBool;
        movement.x = 0;
        movement.y = 0;
    }
}
