using UnityEngine;

public class PauseScreenScript : MonoBehaviour
    //Purpose of this script is to activate the pause screen and stop player movement, what it displays depends on the scene
{
    public GameObject pauseScreen;
    public HeroMoveScript player;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        pauseScreen.SetActive(false);
        player.setPaused(false);
    }

    // Update is called once per frame
    void Update()
    { 
        if (Input.GetKeyDown(KeyCode.Escape))//Pause button
        {
            Debug.Log("ESC pressed");   
            if (pauseScreen.activeSelf)//If pause screen is already visable
            {
                Debug.Log("set false");
                player.setPaused(false);
                pauseScreen.SetActive(false);
            }
            else//Pause screen was off
            {
                Debug.Log("set true");
                player.setPaused(true);
                pauseScreen.SetActive(true);
            }
        }
    }
}
