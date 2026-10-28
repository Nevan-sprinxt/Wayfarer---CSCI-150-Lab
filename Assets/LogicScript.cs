using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIScript : MonoBehaviour
{

   // public LogicScript dmgCalc;//this will let us grab dmg calcs mid game as long as we tag it

    public int playerHP;
    public Text HPText;
    public GameObject gameOverScreen;

    //void Start()
   // {
       // dmgCalc = GameObect.FindGameObjectWithTag("dmgCalc").GetComponent<LogicScript>();
       //Link once dmgCalc is made
    //}

    [ContextMenu("Lower HP")]//Allows you to test without game events
    public void alterHPText()//Placeholder, should take values from dmg calc in the future
    {//dmgCalc can find us thanks to the tag
        playerHP--;
        HPText.text = playerHP.ToString();
        if (playerHP <= 0)
        {
            gameOver();
        }
    }

    [ContextMenu("Increase HP")]
    public void alterHPTextUp()//The real version will only need one because we can use 
    {//negative values to heal
        playerHP++;
        HPText.text = playerHP.ToString();
    }

    public void restartBattle(){//This might be the type of code to go from overworld
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void gameOver()
    {
        gameOverScreen.SetActive(true);
    }
}
