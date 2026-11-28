using UnityEngine;

public class GameStarter : MonoBehaviour
{
    [SerializeField] private SaveController saveController;
    [SerializeField] private SceneChangeScript sceneChanger;

    private void Start()
    {
        if (saveController.HasSaveFile)
        {
            saveController.LoadGame();
        }
        else
        {
            sceneChanger.ChangeSceneByName("OverworldProto");
        }
    }
}
