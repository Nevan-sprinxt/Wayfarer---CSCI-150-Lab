using UnityEngine;

public class GenericEnemy : MonoBehaviour
{
    public SceneChangeScript change;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Put name of scene you want to switch to here and make sure
        //to add it to the build profile
        change.ChangeSceneByName("Combat Scene NG");
       // Debug.Log("YAP");
    }
}
