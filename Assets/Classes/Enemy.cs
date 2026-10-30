using UnityEngine;

public abstract class Enemy : Entity
{
    protected string attackPattern; //Place holder for the enemy's attack pattern, we need to determine how to define this
    protected bool isBoss; //Indicates whether the enemy is a boss or not

    public bool getIsBoss() //Function that checks if the enemy is a boss, important for flee function later to determine if player can flee from this enemy
    {
        return isBoss;
    }
    
}
