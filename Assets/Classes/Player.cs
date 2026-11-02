using UnityEngine;

public class Player : Entity
{
    private Weapon equippedWeapon = null; //The weapon that the player currently has equipped, can be null if no weapon is equipped

    public EndAndHealthScript display;

    public Player()
    {
        maxHealth = 100;
        currentHealth = 55;
        defense = 5;
    }
    void Start()
    {
        equippedWeapon = new Weapon(); //Indicates that the player has no weapon equipped at the start of the game
        display.applyDmgToHero(-currentHealth);
        display.setMaxHero(maxHealth.ToString());
    }
}
