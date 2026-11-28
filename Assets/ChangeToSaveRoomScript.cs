using UnityEngine;

public class ChangeToSaveRoomScript : MonoBehaviour
{
    public SceneChangeScript change;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        change = FindAnyObjectByType<SceneChangeScript>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Put name of scene you want to switch to here and make sure
        //to add it to the build profile
       // if (collision.CompareTag("Player"))
       // {
            change.ChangeSceneByName("SaveRoom");
       // }
        Debug.Log("WHY WOULD YOU CHANGE THIS");
    }
}
