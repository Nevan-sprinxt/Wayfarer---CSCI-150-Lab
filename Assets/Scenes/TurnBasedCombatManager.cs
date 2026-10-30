using JetBrains.Annotations;
using UnityEngine;

public class TurnBasedCombatManager : MonoBehaviour
{

    private enum CombatState { START, PLAYERTURN, ENEMYTURN, DAMAGESTEP, WON, LOST }
    private CombatState state;

    void Start()
    {
        state = CombatState.START;
        StartCoroutine(SetupBattle());
    }
    System.Collections.IEnumerator SetupBattle()
    {
        Debug.Log("Battle Starting...");
        yield return new WaitForSeconds(2f);

        state = CombatState.PLAYERTURN;
        PlayerTurn();

    }

    void PlayerTurn()
    {
        Debug.Log("Select Action");
        // Enable player UI control/buttons
    }
    public void OnSelectedAction()
    {
        if (state != CombatState.PLAYERTURN) return;
        state = CombatState.ENEMYTURN;
        StartCoroutine(EnemyTurn());
    }

    System.Collections.IEnumerator EnemyTurn()
    {
        Debug.Log("Enemy Attacks!");
        yield return new WaitForSeconds(2f);

        state = CombatState.PLAYERTURN;
        PlayerTurn();
    }

}
