using UnityEngine;

public class Player : Entity
{
    //private weapon currentWeapon; //Place holder for the player's current weapon, once weapon class is defined we can implement this

    public EndAndHealthScript display;

    public Player()
    {
        maxHealth = 100;
        currentHealth = 55;
        defense = 5;
    }
}
