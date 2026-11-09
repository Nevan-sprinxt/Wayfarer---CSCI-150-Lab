using UnityEngine;

public abstract class Entity : MonoBehaviour
{
    //Initial stats of the entity, do we want status effects and modifiers to effect these or be applied elsewhere?
    //Serialized field makes it visible and editable in the Unity Inspector while keeping it protected in code
    [SerializeField] protected int attack;
    [SerializeField] protected double abilityStrength; //Effects how strong the entity's abilities are
    [SerializeField] protected double abilityRange; //Effects how far the entity's abilities can reach
    [SerializeField] protected double abilityEfficiency; //Effects how efficiently the entity uses its abilities, meaning might consume less resources
    [SerializeField] protected double abilityPrecision; //Effects...
    [SerializeField] protected int currentHealth;
    [SerializeField] protected int defense; //Reduces incoming damage
    [SerializeField] protected int maxHealth;
    [SerializeField] protected int ond; //Games magic or mana points/energy of the entity
    [SerializeField] protected double critRate; //Effects the critical hit chance of the entity
    [SerializeField] protected double critDamage; //Effects the critical hit damage of the entity

    //Functions that handle health
    public void takeDamage(int damage) //Function that will later use CalculateDamage() to determine the actual damage taken
    {
        currentHealth -= damage;
        currentHealth = Mathf.Max(0, currentHealth);
    }

    public void heal(int amount) //Function that heals the entity by the passsed in amount usually determined by items or abilities
    {
        currentHealth += amount;
        if (currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }
    }

    public void setHealth(int health)
    {
        currentHealth = health;
    }

    //Functions that change stats, temporary placeholders for now for above question about stat changes
    public void increaseAbilityStrength(int amount)
    {
        abilityStrength += amount;
    }

    //These functions are for retrieving data entity's current state
    public virtual int getAttack() //NG need this for dmgCalc
    {
        return attack;
    }
    public int getCurrentHealth()
    {
        return currentHealth;
    }

    public int getMaxHealth()
    {
        return maxHealth;
    }

    public virtual int getDefense()
    {
        return defense;
    }

    public virtual double getCritDamage()
    {
        return critDamage;
    }
    public virtual double getCritRate()
    {
        return critRate;
    }

    public double getAbilityStrength()
    {
        return abilityStrength;
    }

    public double getAbilityRange()
    {
        return abilityRange;
    }

    public double getAbilityEfficiency()
    {
        return abilityEfficiency;
    }

    public double getAbilityPrecision()
    {
        return abilityPrecision;
    }

    public int getOnd()
    {
        return ond;
    }

    //testing functions
    void killEntity()
    {
        currentHealth = 0;
    }
}
