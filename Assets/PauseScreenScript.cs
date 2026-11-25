using UnityEngine;

public class PauseScreenScript : MonoBehaviour
    //Purpose of this script is to activate the pause screen and stop player movement, what it displays depends on the scene
{
    [SerializeField] private GameObject pauseScreen;

    private HeroMoveScript playerMover;

    void Start()
    {
        if (Player.Instance == null)
        {
            Debug.LogError("Player Instance Not Found");
            return;
        }

        playerMover = Player.Instance.GetComponentInChildren<HeroMoveScript>();

        if (playerMover == null)
        {
            Debug.LogError("PlayerMover Not Found");
            return;
        }

        if (pauseScreen == null)
        {
            Debug.LogError("PauseScreen Not Assigned");
            return;
        }

        pauseScreen.SetActive(false);
        playerMover.setPaused(false);
    }

    void Update()
    {
        if (playerMover == null || pauseScreen == null)
            return;

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Debug.Log("ESC pressed");

            bool isPaused = !pauseScreen.activeSelf;

            playerMover.setPaused(isPaused);
            pauseScreen.SetActive(isPaused);
        }
    }
}