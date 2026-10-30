using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIScript : MonoBehaviour
{

    //public int dmgCalc;//this will let us grab dmg calcs mid game as long as we tag it, I'll figure out how to differentiate from hero to enemy later
    //I'm hoping it's easy to call

    public int playerHP;
    public int enemyHP;
    public Text playerHPText;
    public Text enemyHPText;

    public GameObject gameOverScreen;
    public GameObject battleWonScreen;

    //void Start()
    // {
    // dmgCalc = GameObect.FindGameObjectWithTag("dmgCalc").GetComponent<LogicScript>();
    //Link once dmgCalc is made
    //}

    [ContextMenu("Lower HP")]//Allows you to test without game events
    public void alterHPText()//Placeholder, should take values from dmg calc in the future
    {//dmgCalc can find us thanks to the tag
        playerHP--;
        playerHPText.text = playerHP.ToString();
        if (playerHP <= 0)
        {
            gameOver();
        }
    }

    [ContextMenu("Lower enemy HP")]//Allows you to test without game events
    public void alterEnemyHPText()//Placeholder, should take values from dmg calc in the future
    {//dmgCalc can find us thanks to the tag
        enemyHP--;
        enemyHPText.text = enemyHP.ToString();
        if (enemyHP <= 0)
        {
            battleWon();
        }
    }

    [ContextMenu("Increase HP")]
    public void alterHPTextUp()//The real version will only need one because we can use 
    {//negative values to heal
        playerHP++;
        playerHPText.text = playerHP.ToString();
    }

    public void restartBattle(){//This might be the type of code to go from overworld to combat and vice versa
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    //We can call these two from the dmgCalc
    //https://discussions.unity.com/t/best-way-to-get-variable-from-another-script-c-unity/720634/2

    public void applyDmgToHero(int dmg)
    {
        playerHP-=dmg;
        playerHPText.text = playerHP.ToString();
        if (playerHP <= 0)
        {
            gameOver();
        }
    }

    public void applyDmgToEnemy(int dmg)
    {
        enemyHP -= dmg;
        enemyHPText.text = enemyHP.ToString();
        if (enemyHP <= 0)
        {
            battleWon();
        }
    }

    public void gameOver()
    {
        gameOverScreen.SetActive(true);
    }

    public void battleWon()
    {
        battleWonScreen.SetActive(true);
    }
}
