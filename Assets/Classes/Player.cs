using UnityEngine;

public class Player : Entity
{
    private Weapon equippedWeapon;

    public EndAndHealthScript display;

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

    public override int getAttack()
    {
        int weaponAttack = (equippedWeapon != null) ? equippedWeapon.getWeaponAttack() : 0;
        return attack + weaponAttack; // Innate (0) + Weapon Attack
    }

    public void EquipWeapon(Weapon newWeapon) // Placeholder equip/swap weapons during gameplay
    {
        equippedWeapon = newWeapon;
        int equippedAtk = (equippedWeapon != null) ? equippedWeapon.getWeaponAttack() : 0;
        Debug.Log($"Player equipped weapon with {equippedAtk} attack power.");
    }
}
