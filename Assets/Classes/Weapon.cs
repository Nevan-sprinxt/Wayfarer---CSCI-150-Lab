using UnityEngine;

[CreateAssetMenu(fileName = "Weapon", menuName = "Scriptable Objects/Weapon")]
public class Weapon : ScriptableObject
{
    [SerializeField] private string weaponName;
    [SerializeField] private int level;
    [SerializeField] private int damage; 
    [SerializeField] private int defense;
    [SerializeField] private int maxStrain;
    [SerializeField] private const int baseRuneSlots = 1;
    [SerializeField] private Rune[] runeSlots = new Rune[baseRuneSlots];

    public Weapon()
    {
        weaponName = "Fist";
        level = 0;
        damage = 0;
        defense = 0;
        maxStrain = 0;
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
        damage = level * 5; //Placeholder calculation, we can change this later
        defense = level * 2; //Placeholder calculation, we can change this later
    }
}
