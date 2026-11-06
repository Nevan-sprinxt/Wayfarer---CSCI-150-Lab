using UnityEngine;

[CreateAssetMenu(fileName = "Weapon", menuName = "Scriptable Objects/Weapon")]
public class Weapon : ScriptableObject
{
    [SerializeField] protected string weaponName;
    [SerializeField] protected int level;
    [SerializeField] protected int weaponAttack; 
    [SerializeField] protected int weaponDefense;
    [SerializeField] protected int maxStrain;
    [SerializeField] protected const int baseRuneSlots = 8;
    [SerializeField] private Rune[] runeSlots = new Rune[baseRuneSlots];

    public Weapon()
    {
        weaponName = "Fist";
        level = 0;
        weaponAttack = 0;
        weaponDefense = 0;
        maxStrain = 0;
    }

    public int getWeaponAttack()
    {
        return weaponAttack;
    }

    public void calcMaxStrain(int level) //Function that calculates the maximum strain of the weapon based on its level, this is a placeholder for now until we determine how to calculate it
    {
        maxStrain = level * 10; //Placeholder calculation, we can change this later
    }

    public int calculateRuneSlots(int level) //Function that calculates the number of rune slots the weapon has based on its level, this is a placeholder for now until we determine how to calculate it
    {
        return baseRuneSlots + (level / 5); //Placeholder calculation, we can change this later
    }
    
    public void levelUp() //Function that increases the level of the weapon by the passed in amount, usually determined by items or abilities
    {
        level++;
        int slots = calculateRuneSlots(level);
        System.Array.Resize(ref runeSlots, slots);
    }

    public void recalculateStats(int level) //Function that recalculates the stats of the weapon based on its level, this is a placeholder for now until we determine how to calculate it
    {
        weaponAttack = level * 5; //Placeholder calculation, we can change this later
        weaponDefense = level * 2; //Placeholder calculation, we can change this later
    }
}
