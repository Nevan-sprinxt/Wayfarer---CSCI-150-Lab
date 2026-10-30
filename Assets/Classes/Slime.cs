using UnityEngine;

public class Slime : Enemy
{
    //Dont know if there will be a slime enemy this is just a placeholder to show how to define a basic enemy subclass

    public Slime()
    {
        maxHealth = 50;
        currentHealth = maxHealth;
        defense = 1;
        isBoss = false; //Indicates that this enemy is not a boss
        attackPattern = "Basic"; //Placeholder for the slime's attack pattern
    }

}
