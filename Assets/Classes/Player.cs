using UnityEngine;

public class Player : Entity
{
    private Weapon equippedWeapon;

    public Player()
    {
        maxHealth = 100;
        currentHealth = maxHealth;
        defense = 5;
    }

}
