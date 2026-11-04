using UnityEngine;

public class TestingScript : MonoBehaviour
{
    public Player playerObject;
    private Enemy[] enemies;
    public GameObject playerHealthDisplay;
    public GameObject enemyHealthDisplay;

    public void TestPlayerTakesDamage()
    {
        int initialHealth = playerObject.getCurrentHealth();
        int damageAmount = 10; // Example damage amount
        playerObject.takeDamage(damageAmount);
        int expectedHealth = initialHealth - damageAmount;
        Debug.Assert(playerObject.getCurrentHealth() == expectedHealth, "Player health did not decrease correctly");
        playerObject.setHealth(initialHealth); // Reset health for further tests
    }

    public void TestPlayerHeals()
    {
        int initialHealth = playerObject.getCurrentHealth();
        int healAmount = 10; // Example heal amount
        playerObject.heal(healAmount);
        int expectedHealth = Mathf.Min(initialHealth + healAmount, playerObject.getMaxHealth());
        Debug.Assert(playerObject.getCurrentHealth() == expectedHealth, "Player health did not increase correctly");
        playerObject.setHealth(initialHealth); // Reset health for further tests
    }

    public void TestMaxPlayerHealth()
    {
        int initialHealth = playerObject.getCurrentHealth();
        int maxHealth = playerObject.getMaxHealth();
        int healAmount = (maxHealth * 2); // Example heal amount
        playerObject.heal(healAmount);
        Debug.Assert(playerObject.getCurrentHealth() == maxHealth, "Player health did not reach maximum correctly");
        playerObject.setHealth(initialHealth); // Reset health for further tests
    }

    public void TestEnemyTakesDamage(Entity entity)
    {
        int initialHealth = entity.getCurrentHealth();
        int damageAmount = 10; // Example damage amount
        entity.takeDamage(damageAmount);
        int expectedHealth = initialHealth - damageAmount;
        Debug.Assert(entity.getCurrentHealth() == expectedHealth, "Enemy health did not decrease correctly");
        entity.setHealth(initialHealth); // Reset health for further tests
    }

    public void TestEnemyHeals(Entity entity)
    {
        int initialHealth = entity.getCurrentHealth();
        int healAmount = 10; // Example heal amount
        entity.heal(healAmount);
        int expectedHealth = Mathf.Min(initialHealth + healAmount, entity.getMaxHealth());
        Debug.Assert(entity.getCurrentHealth() == expectedHealth, "Enemy health did not increase correctly");
        entity.setHealth(initialHealth); // Reset health for further tests
    }

    public void TestMaxEnemyHealth(Entity entity)
    {
        int initialHealth = entity.getCurrentHealth();
        int maxHealth = entity.getMaxHealth();
        int healAmount = (maxHealth * 2); // Example heal amount
        entity.heal(healAmount);
        Debug.Assert(entity.getCurrentHealth() == maxHealth, "Enemy health did not reach maximum correctly");
        entity.setHealth(initialHealth); // Reset health for further tests
    }

    public void TestPlayerHealthDisplay()
    {
        int initialHealth = playerObject.getCurrentHealth();
        playerHealthDisplay.GetComponent<UnityEngine.UI.Text>().text = "Player Health: " + initialHealth.ToString();
        Debug.Assert(playerHealthDisplay.GetComponent<UnityEngine.UI.Text>().text == "Player Health: " + initialHealth.ToString(), "Player health display did not update correctly");
    }

    public void TestEnemyHealthDisplay(Entity entity)
    {
        int initialHealth = entity.getCurrentHealth();
        enemyHealthDisplay.GetComponent<UnityEngine.UI.Text>().text = "Enemy Health: " + initialHealth.ToString();
        Debug.Assert(enemyHealthDisplay.GetComponent<UnityEngine.UI.Text>().text == "Enemy Health: " + initialHealth.ToString(), "Enemy health display did not update correctly");
    }

    public void TestPlayerHealthDisplayChange()
    {
        //test taking damage and updating the display
        int initialHealth = playerObject.getCurrentHealth();
        int damageAmount = 10; // Example damage amount
        playerObject.takeDamage(damageAmount);
        playerHealthDisplay.GetComponent<UnityEngine.UI.Text>().text = "Player Health: " + playerObject.getCurrentHealth().ToString();
        Debug.Assert(playerHealthDisplay.GetComponent<UnityEngine.UI.Text>().text == "Player Health: " + playerObject.getCurrentHealth().ToString(), "Player health display did not update correctly after taking damage");
        playerObject.setHealth(initialHealth); // Reset health for further tests
        
        //Test Healing and updating the display
        int healAmount = 10; // Example heal amount
        playerObject.heal(healAmount);
        playerHealthDisplay.GetComponent<UnityEngine.UI.Text>().text = "Player Health: " + playerObject.getCurrentHealth().ToString();
        Debug.Assert(playerHealthDisplay.GetComponent<UnityEngine.UI.Text>().text == "Player Health: " + playerObject.getCurrentHealth().ToString(), "Player health display did not update correctly after healing");
        playerObject.setHealth(initialHealth); // Reset health for further tests
    }

    public void TestEnemyHealthDisplayChange(Entity entity)
    {
        int initialHealth = entity.getCurrentHealth();

        //test taking damage and updating the display
        int damageAmount = 10; // Example damage amount
        entity.takeDamage(damageAmount);
        enemyHealthDisplay.GetComponent<UnityEngine.UI.Text>().text = "Enemy Health: " + entity.getCurrentHealth().ToString();
        Debug.Assert(enemyHealthDisplay.GetComponent<UnityEngine.UI.Text>().text == "Enemy Health: " + entity.getCurrentHealth().ToString(), "Enemy health display did not update correctly after taking damage");
        entity.setHealth(initialHealth); // Reset health for further tests
        
        //Test Healing and updating the display
        int healAmount = 10; // Example heal amount
        entity.heal(healAmount);
        enemyHealthDisplay.GetComponent<UnityEngine.UI.Text>().text = "Enemy Health: " + entity.getCurrentHealth().ToString();
        Debug.Assert(enemyHealthDisplay.GetComponent<UnityEngine.UI.Text>().text == "Enemy Health: " + entity.getCurrentHealth().ToString(), "Enemy health display did not update correctly after healing");
        entity.setHealth(initialHealth); // Reset health for further tests
    }

    public void FindPlayer()
    {
        playerObject = FindAnyObjectByType<Player>();
        if (playerObject == null)
        {
            Debug.LogError("Player object not found in the scene.");
        }
    }

    public void FindEnemies()
    {
        enemies = FindObjectsByType<Enemy>();
        if (enemies.Length == 0)
        {
            Debug.LogError("No enemy objects found in the scene.");
        }
    }

    void RunAllPlayerTests()
    {
        TestPlayerTakesDamage();
        TestPlayerHeals();
        TestMaxPlayerHealth();
        TestPlayerHealthDisplay();
        TestPlayerHealthDisplayChange();
    }

    void Start()
    {
        FindPlayer();
        FindEnemies();

        foreach (Enemy enemy in enemies)
        {
            TestEnemyTakesDamage(enemy);
            TestEnemyHeals(enemy);
            TestMaxEnemyHealth(enemy);
            TestEnemyHealthDisplay(enemy);
            TestEnemyHealthDisplayChange(enemy);
        }

        RunAllPlayerTests();

        
    }


}
