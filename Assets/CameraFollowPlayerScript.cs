using UnityEngine;

public class CameraFollowPlayerScript : MonoBehaviour
{
    public Player player; 
    public Vector3 offset;        // Camera distance from the player
    public float smoothTime = 0.25f; // Time taken to catch up to the player

    private Vector3 velocity = Vector3.zero;
    //Camera limits
    [SerializeField]
    float leftLimit;
    [SerializeField]
    float rightLimit;
    [SerializeField]
    float bottomLimit;
    [SerializeField]
    float topLimit;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player = Player.Instance;//To try and preserve player between scenes
    }

    // Update is called once per frame

    void Update()
    {
    if (player != null)
         {
             // Calculate desired position
         Vector3 targetPosition = player.transform.position + offset;

             // Smoothly move the camera to that position
         transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime);
         }
        transform.position = new Vector3
            (
                //https://www.youtube.com/watch?v=05VX2N9_2_4 used this video to figure this out
                //Clamp is a way to put a min and a max on a value
                Mathf.Clamp(transform.position.x, leftLimit, rightLimit),
                Mathf.Clamp(transform.position.y, bottomLimit, topLimit),
                transform.position.z//We aren't messing with the z value
            );
    }
}
