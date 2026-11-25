using UnityEngine;

public class Slime : Enemy
{
    //Dont know if there will be a slime enemy this is just a placeholder to show how to define a basic enemy subclass
    [Header("Slime Combat Stats")]
    [SerializeField] private double slimeCritRate = 0.15;   // 15% crit chance (0.15)
    [SerializeField] private double slimeCritDamage = 2.0;  // 2.0x crit multiplier

    public EndAndHealthScript display;

    private void Awake()
    {
        maxHealth = 300;
        currentHealth = 275;
        defense = 30;
        attack = 200;
        attackPattern = "Squishy Bounce";
        isBoss = false;

        critRate = slimeCritRate;
        critDamage = slimeCritDamage;
    }

    /*
    public Slime()
    {
        attack = 5;
        maxHealth = 50;
        currentHealth = maxHealth;
        defense = 1;
        isBoss = false; //Indicates that this enemy is not a boss
        attackPattern = "Basic"; //Placeholder for the slime's attack pattern
    }
    */
}
