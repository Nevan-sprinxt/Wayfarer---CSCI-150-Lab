using UnityEngine;

public class PlayerToWayfarerScript : MonoBehaviour
{
    public GameObject Wayfarer;//PLAYER and WAYFARER are DIFFERENT so I made this to make the new camera follow script work
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        transform.position = Wayfarer.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Wayfarer.transform.position;
    }
}
