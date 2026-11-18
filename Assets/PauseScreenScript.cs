using UnityEngine;

public class PauseScreenScript : MonoBehaviour
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
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Debug.Log("ESC pressed");   
            if (pauseScreen.activeSelf)
            {
                Debug.Log("set false");
                player.setPaused(false);
                pauseScreen.SetActive(false);
            }
            else
            {
                Debug.Log("set true");
                player.setPaused(true);
                pauseScreen.SetActive(true);
            }
        }
    }
}
