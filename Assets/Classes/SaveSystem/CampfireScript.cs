using UnityEngine;

public class CampfireScript : MonoBehaviour
{
    [SerializeField] private SaveController saveController;
    private void Start()
    {
        saveController = FindAnyObjectByType<SaveController>();
    }

    private bool playerInRange;

    private void Update()
    {
        if (playerInRange && Input.GetKeyDown(KeyCode.E))
        {
            saveController.SaveGame();
            //Debug.Log("Saved at campfire!");
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = true;
            //Debug.Log("Player entered campfire range!");
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = false;
            //Debug.Log("Player left campfire range!");
        }
    }
}
