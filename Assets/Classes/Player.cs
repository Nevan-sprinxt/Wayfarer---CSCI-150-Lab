using UnityEngine;

public class Player : Entity
{
    [SerializeField] private Weapon startingWeapon;
    private Weapon equippedWeapon;

    public EndAndHealthScript display;

    private void Awake()
    {
        maxHealth = 600;

        // Sustained Damage Check: Only initialize to max health if it hasn't been set yet
        if (currentHealth <= 0)
        {
            currentHealth = maxHealth;
        }

        attack = 0;
        defense = 150;
        critRate = 0;
        critDamage = 0;

        abilityStrength =   1.00;
        abilityEfficiency = 1.00;
        abilityRange =      1.00;
        abilityPrecision =  1.00;
        ond = 100;
    }

    private void Start()
    {
        // Equip starting weapon after all Awake() calls across the scene finish
        if (startingWeapon != null)
        {
            EquipWeapon(startingWeapon);
        }
        else
        {
            Debug.Log("No starting weapon assigned in Inspector. Player is bare-handed.");
        }
    }


    /*
    public Player()
    {
        attack = 0;
        maxHealth = 600;
        currentHealth = 600;
        defense = 150;
        abilityStrength =   1.00;
        abilityEfficiency = 1.00;
        abilityRange =      1.00;
        abilityPrecision =  1.00;
        ond = 100;
        critRate = 0.50;
        critDamage = 2.00;
    }
    */
    public Weapon GetEquippedWeapon()
    {
        return equippedWeapon;
    }

    public override int getAttack()
    {
        // If a weapon is equipped, attack matches the weapon's attack power. Bare hands = 0.
        return (equippedWeapon != null) ? equippedWeapon.getWeaponAttack() : 0;
    }

    public override int getDefense()
    {
        int weaponDefenseBonus = (equippedWeapon != null) ? equippedWeapon.getWeaponDefense() : 0;
        return defense + weaponDefenseBonus; // 150 base + weapon bonus
    }

    public override double getCritRate()
    {
        // Crit stats are unique to the weapon being wielded
        return (equippedWeapon != null) ? equippedWeapon.getWeaponCritRate() : 0.0;
    }

    public override double getCritDamage()
    {
        return (equippedWeapon != null) ? equippedWeapon.getWeaponCritDamage() : 0.0;
    }

    public void EquipWeapon(Weapon newWeapon) // Placeholder equip/swap weapons during gameplay
    {
        equippedWeapon = newWeapon;
        int equippedAtk = (equippedWeapon != null) ? equippedWeapon.getWeaponAttack() : 0;
        Debug.Log($"Player equipped weapon with {equippedAtk} attack power.");
    }
}
