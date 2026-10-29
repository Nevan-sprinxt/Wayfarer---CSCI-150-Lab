using UnityEngine;

public class Player : Entity
{
    //private weapon currentWeapon; //Place holder for the player's current weapon, once weapon class is defined we can implement this

    public Player()
    {
        maxHealth = 100;
        currentHealth = maxHealth;
        defense = 5;
    }

}
