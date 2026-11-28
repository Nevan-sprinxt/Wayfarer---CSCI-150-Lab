using UnityEngine;
using System.Collections;

//Include this for scene changes to be possible
using UnityEngine.SceneManagement;

public class SceneChangeScript : MonoBehaviour
{
    [SerializeField] private string startingScene = "OverworldProto";

    public bool isChangingScene;

    private Scene persistentScene;

    private void Awake()
    {
        persistentScene = gameObject.scene;
    }

    /*
    private void Start()
    {
        ChangeSceneByName(startingScene);
    }
    */

    //public void ChangeSceneByName(string sceneName)
    //{
    //    StartCoroutine(ChangeScene(sceneName, null));
    //} 
    //I don't know why you changed this when it worked before and you ended up making a different scene change
    //Function anyways
    public void ChangeSceneByName(string name)
    {
        SceneManager.LoadScene(name);
    }

    public void LoadSavedScene(string sceneName, Vector3 savedPosition)
    {
        StartCoroutine(ChangeScene(sceneName, savedPosition));
    }

    private IEnumerator ChangeScene(string sceneName, Vector3? savedPosition)
    {
        Scene previousScene = SceneManager.GetActiveScene();

        // Check whether the scene is already loaded
        Scene newScene = SceneManager.GetSceneByName(sceneName);

        if (!newScene.IsValid() || !newScene.isLoaded)
        {
            yield return SceneManager.LoadSceneAsync(
                sceneName,
                LoadSceneMode.Additive
            );

            newScene = SceneManager.GetSceneByName(sceneName);
        }

        if (!newScene.IsValid() || !newScene.isLoaded)
        {
            Debug.LogError("Could not load scene: " + sceneName);
            yield break;
        }

        SceneManager.SetActiveScene(newScene);

        // Loading a save: use the saved position
        if (savedPosition.HasValue)
        {
            Player.Instance.transform.position = savedPosition.Value;
        }
        // Normal transition: use the scene's spawn point
        else
        {
            foreach (GameObject root in newScene.GetRootGameObjects())
            {
                PlayerSpawnPoint spawn =
                    root.GetComponentInChildren<PlayerSpawnPoint>();

                if (spawn != null)
                {
                    Player.Instance.transform.position =
                        spawn.transform.position;
                    break;
                }
            }
        }

        // Unload previous gameplay scene
        if (previousScene.IsValid() &&
            previousScene.isLoaded &&
            previousScene != persistentScene &&
            previousScene != newScene)
        {
            yield return SceneManager.UnloadSceneAsync(previousScene);
        }
    }
}