using UnityEngine;

//Include this for scene changes to be possible
using UnityEngine.SceneManagement;

public class SceneChangeScript : MonoBehaviour
{
    public void ChangeSceneByName(string name)
    {
        SceneManager.LoadScene(name);
    }

}