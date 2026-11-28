using UnityEngine;

public class ChangeToCombatScript : MonoBehaviour
{
    public SceneChangeScript change;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Put name of scene you want to switch to here and make sure
        //to add it to the build profile
        change.ChangeSceneByName("Combat Scene NG");
        // Debug.Log("YAP");
    }
}
