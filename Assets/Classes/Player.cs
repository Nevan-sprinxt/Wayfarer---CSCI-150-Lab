using UnityEngine;

public class Player : Entity
{
    private Weapon equippedWeapon;

    public EndAndHealthScript display;

    public Player()
    {
        maxHealth = 100;
        currentHealth = 55;
        defense = 5;
    }
}
