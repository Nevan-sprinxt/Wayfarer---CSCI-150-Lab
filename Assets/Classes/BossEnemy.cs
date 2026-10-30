using UnityEngine;

public class BossEnemy : Enemy
{
    

    public BossEnemy()
    {
        isBoss = true; //Indicates that this enemy is a boss
        maxHealth = 500;
        currentHealth = maxHealth;
        defense = 10;
        attackPattern = "Boss"; //Placeholder for the boss enemy's attack pattern
    }

}
