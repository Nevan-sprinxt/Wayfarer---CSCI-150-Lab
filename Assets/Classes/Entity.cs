using UnityEngine;

public abstract class Entity : MonoBehaviour
{
    //Initial stats of the entity, do we want status effects and modifiers to effect these or be applied elsewhere?
    //Serialized field makes it visible and editable in the Unity Inspector while keeping it protected in code
    [SerializeField] protected int abilityStrength; //Effects how strong the entity's abilities are
    [SerializeField] protected int abilityRange; //Effects how far the entity's abilities can reach
    [SerializeField] protected int abilityEfficiency; //Effects how efficiently the entity uses its abilities, meaning might consume less resources
    [SerializeField] protected int abilityPrecision; //Effects...
    [SerializeField] protected int currentHealth;
    [SerializeField] protected int defense; //Reduces incoming damage
    [SerializeField] protected int maxHealth;
    [SerializeField] protected int ond; //Games magic or mana points/energy of the entity
    [SerializeField] protected int critRate; //Effects the critical hit chance of the entity

    //Functions that handle health
    public void takeDamage(int damage) //Function that will later use CalculateDamage() to determine the actual damage taken
    {
        currentHealth -= damage;
    }

    public void heal(int amount) //Function that heals the entity by the passsed in amount usually determined by items or abilities
    {
        currentHealth += amount;
        if (currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }
    }

    //Functions that change stats, temporary placeholders for now for above question about stat changes
    public void increaseAbilityStrength(int amount)
    {
        abilityStrength += amount;
    }

    //These functions are for retrieving data entity's current state
    public int getCurrentHealth()
    {
        return currentHealth;
    }

    public int getDefense()
    {
        return defense;
    }
}
