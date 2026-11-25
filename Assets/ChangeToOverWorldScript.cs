using UnityEngine;

public class ChangeToOverWorldScript : MonoBehaviour
{
    public SceneChangeScript change;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        change = FindAnyObjectByType<SceneChangeScript>();
        if(change == null) Debug.Log("Scene Changer not found");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Put name of scene you want to switch to here and make sure
        //to add it to the build profile
        change.ChangeSceneByName("OverworldProto");
        // Debug.Log("YAP");
    }
}
