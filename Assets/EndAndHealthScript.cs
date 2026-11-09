using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EndAndHealthScript : MonoBehaviour
{

   public Player play;
   public Slime slime;


    public Text playerHPText;
    public Text enemyHPText;

    public Text playerMaxHPText;
    public Text enemyMaxHPText;

    public GameObject gameOverScreen;
    public GameObject battleWonScreen;

    void Start()
    {
        gameOverScreen.SetActive(false);
        battleWonScreen.SetActive(false);
        setMaxHero(play.getMaxHealth().ToString());
        playerHPText.text = play.getCurrentHealth().ToString();
        setMaxEnemy(slime.getMaxHealth().ToString());
        enemyHPText.text = slime.getCurrentHealth().ToString();
    }


    [ContextMenu("Lower HP")]//Allows you to test without game events
    public void alterHPText()//Placeholder, should take values from dmg calc in the future
    {//dmgCalc can find us thanks to the tag
        play.takeDamage(20);
        playerHPText.text = play.getCurrentHealth().ToString();
        if (play.getCurrentHealth() <= 0)
        {
            gameOver();
        }
    }

    [ContextMenu("Lower enemy HP")]//Allows you to test without game events
    public void alterEnemyHPText()//Placeholder, should take values from dmg calc in the future
    {//dmgCalc can find us thanks to the tag
        slime.takeDamage(20);
        enemyHPText.text = slime.getCurrentHealth().ToString();
        if (slime.getCurrentHealth() <= 0)
        {
            battleWon();
        }
    }

    public void UpdateUI()
    {
        if (play != null)
        {
            playerHPText.text = play.getCurrentHealth().ToString();
        }
        if (slime != null)
        {
            enemyHPText.text = slime.getCurrentHealth().ToString();
        }
    }

    public void restartBattle()
    {//This might be the type of code to go from overworld to combat and vice versa
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void setMaxHero(string HP)
    {
        playerMaxHPText.text = HP;
    }

    public void setMaxEnemy(string HP)
    {
        enemyMaxHPText.text = HP;
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
