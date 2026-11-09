//using NUnit.Framework.Constraints;
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BattleMenuManager : MonoBehaviour
{
    private enum CombatState { START, PLAYERTURN, ENEMYTURN, DAMAGESTEP, WON, LOST }

    [Header("Combat State")]
    [SerializeField] private CombatState state;
    [SerializeField] private Enemy activeEnemy;

    [Header("Settings Menu")]
    [SerializeField] private GameObject settingsMenu; // Need Settings panel + object

    [Header("Menu Panels")]
    [SerializeField] private GameObject combatMenu;       // Actions, Abilities, Items, Flee
    [SerializeField] private GameObject abilitiesSubmenu; // 4 ability choices
    [SerializeField] private GameObject actionsSubmenu;        // Attack, Defend
    [SerializeField] private GameObject itemsSubmenu;          // Inventory List Panel

    [Header("Combat Data")]
    [SerializeField] private string[] abilityNames = { "Ability1", "Ability2", "Ability3", "Ability4" };

    [Header("Combat Log")]
    [SerializeField] private TextMeshProUGUI combatLogText;    // Text UI for log messages
    [SerializeField] private int maxLogLines = 5;              // Max lines to keep in log
    private Queue<string> logQueue = new Queue<string>();

    [Header("Items Inventory")]
    [SerializeField] private Transform itemButtonContainer;    // Content transform of ScrollView
    [SerializeField] private GameObject itemButtonPrefab;      // Prefab button for inventory items
    [SerializeField] private List<string> playerInventory = new List<string> { "Ugly Stick", "Nice Stick", "Subpar Stick", "Premium Stick" }; // Temporary, for testing

    [Header("Player Reference")]
    [SerializeField] private Player player; // Assign your Player GameObject in the Inspector

    [Header("UI Reference")]
    [SerializeField] private EndAndHealthScript endAndHealthScript;

    [Header("Combat Buffs")]
    [SerializeField] private double defenseMultiplier = 1.50; // 1.50x defense boost
    private int originalDefense = 0;
    private bool isPlayerDefending = false;
    private bool isEnemyDefending = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Debug.Log("BattleMenuManager: Start() executed.");
        state = CombatState.START;
        StartCoroutine(SetupBattle());
    }

    IEnumerator SetupBattle()
    {
        Debug.Log("BattleMenuManager: SetupBattle() coroutine started.");
        yield return new WaitForSeconds(1f);
        UpdateCombatLog("The enemy has appeared! Quick, respond to the threat!");

        state = CombatState.PLAYERTURN;
        PlayerTurn();
    }

    void PlayerTurn()
    {
        Debug.Log("BattleMenuManager: PlayerTurn() reached. Current state: PLAYERTURN.");
        OpenCombatMenu();
    }

    private void OpenSettingsMenu()
    {
        Debug.Log("BattleMenuManager: OpenSettingsMenu() called.");
        combatMenu.SetActive(false);
        abilitiesSubmenu.SetActive(false);
        actionsSubmenu.SetActive(false);
        itemsSubmenu.SetActive(false);

        if (settingsMenu != null)
        {
            settingsMenu.SetActive(true);
            Debug.Log("BattleMenuManager: Settings menu successfully activated.");
        }
    }

    public void OpenCombatMenu()
    {
        Debug.Log("BattleMenuManager: OpenCombatMenu() called.");
        CloseAllSubmenus(); 
        if (combatMenu != null) combatMenu.SetActive(true);
    }

    public void OpenAbilitiesSubmenu()
    {
        Debug.Log("BattleMenuManager: OpenAbilitiesSubmenu() called.");
        if (state != CombatState.PLAYERTURN)
        {
            Debug.LogWarning("BattleMenuManager: Ignored OpenAbilitiesSubmenu - not player's turn.");
            return;
        }
        CloseAllSubmenus(); 
        if (abilitiesSubmenu != null) abilitiesSubmenu.SetActive(true);
    }

    public void OpenActionsSubmenu()
    {
        Debug.Log("BattleMenuManager: OpenActionsSubmenu() called.");
        if (state != CombatState.PLAYERTURN)
        {
            Debug.LogWarning("BattleMenuManager: Ignored OpenActionsSubmenu - not player's turn.");
            return;
        }
        CloseAllSubmenus(); 
        if (actionsSubmenu != null) actionsSubmenu.SetActive(true);
    }

    public void OpenItemsSubmenu()
    {
        Debug.Log("BattleMenuManager: OpenItemsSubmenu() called.");
        if (state != CombatState.PLAYERTURN)
        {
            Debug.LogWarning("BattleMenuManager: Ignored OpenItemsSubmenu - not player's turn.");
            return;
        }
        CloseAllSubmenus(); 
        if (itemsSubmenu != null) itemsSubmenu.SetActive(true);
        PopulateInventoryUI();
    }

    public void OnAttackSelected()
    {
        Debug.Log("BattleMenuManager: OnAttackSelected() called.");
        if (state != CombatState.PLAYERTURN) return;

        if (player == null) // Safety check for null reference
        {
            Debug.LogError("BattleMenuManager: 'player' reference is NULL! Assign it in the Inspector.");
            return;
        }
        if (activeEnemy == null)
        {
            Debug.LogError("BattleMenuManager: 'activeEnemy' reference is NULL! Assign an Enemy in the Inspector or runtime setup.");
            return;
        }

        // 1. Fetch stats for the calculation
        int initiatorAtk = player.getAttack();
        int targetDef = activeEnemy.getDefense();

        // Apply enemy defense multiplier if they are defending (1.50x)
        if (isEnemyDefending)
        {
            targetDef = Mathf.RoundToInt(targetDef * (float)defenseMultiplier);
            UpdateCombatLog("The enemy braced and boosted their defense!");
        }

        // 2. Roll for critical hit using the player's critRate
        bool rollCrit = UnityEngine.Random.value <= player.getCritRate(); // Checks if Random (Ranges from 0.0 to 1.0) is less than or equal to Crit Rate. Sets true if it is.
        int finalDamage = 0;

        if (rollCrit)
        {
            UpdateCombatLog("Critical Hit!");
            // Critical hit calculation: (Attack - Defense) * critDamage
            finalDamage = critDmgCalc(initiatorAtk, targetDef, player.getCritDamage());
        }
        else
        {
            // Standard damage calculation: Attack - Defense
            finalDamage = dmgCalc(initiatorAtk, targetDef);
        }

        // 3. Apply the damage using Entity's takeDamage() method
        activeEnemy.takeDamage(finalDamage);

        endAndHealthScript.UpdateUI();

        // 4. Log results and update combat UI text
        //UpdateCombatLog($"Player attacked enemy for {finalDamage} damage! Enemy HP: {activeEnemy.getCurrentHealth()}");

        // 5. Check if the enemy has been defeated
        if (activeEnemy.getCurrentHealth() <= 0)
        {
            state = CombatState.WON;
            UpdateCombatLog("You have defeated the enemy!");
            if (endAndHealthScript != null)
            {
                endAndHealthScript.battleWon(); 
            }
            CloseAllSubmenus();
            return;
        }

        if (player.GetEquippedWeapon() == null)
        {
            // Unarmed attack log
            UpdateCombatLog($"You hit the enemy with your bare hands! Punching armor hurts your hand... (Dealt {finalDamage} damage)");
        }
        else
        {
            // Weapon attack log
            string weaponName = player.GetEquippedWeapon().name;
            UpdateCombatLog($"You strike the enemy with your {weaponName} dealing {finalDamage} damage! Enemy HP: {activeEnemy.getCurrentHealth()}");
        }
        // Should also proceed to combat turn resolution
        StartCoroutine(ProcessEnemyTurnAfterAction());
    }

    private int dmgCalc(int initiatorAtk, int targetDef)
    {
        // Adjusted attack with a damage floor of 0 so defense doesn't heal[cite: 3, 4]
        int adjustedAtk = Mathf.Max(0, initiatorAtk - targetDef);
        return adjustedAtk;
    }

    private int critDmgCalc(int initiatorAtk, int targetDef, double critDamageMultiplier)
    {
        int adjustedAtk = Mathf.Max(0, initiatorAtk - targetDef); 
        return Mathf.RoundToInt((float)(adjustedAtk * critDamageMultiplier)); 
    }

    public void OnDefendSelected()
    {
        Debug.Log("BattleMenuManager: OnDefendSelected() called.");
        if (state != CombatState.PLAYERTURN) return;

        if (player != null)
        {
            // Store original defense if not already defending, then apply multiplier
            originalDefense = player.getDefense();
            int boostedDefense = Mathf.RoundToInt(originalDefense * (float)defenseMultiplier);

            // Note: You can add a temporary modifier method in Player/Entity, or handle it here
            isPlayerDefending = true;

            UpdateCombatLog($"Player braced and chose Defend! Defense boosted by {defenseMultiplier}x (to {boostedDefense}).");
        }
        else
        {
            UpdateCombatLog("Player braced and chose Defend!");
        }
        // Add defense state logic 
        // Should proceed to combat turn resolution
        StartCoroutine(ProcessEnemyTurnAfterAction());
    }

    // This handles all 4 abilities using an index (0, 1, 2, or 3)
    public void OnAbilitySelected(int abilityIndex)
    {
        Debug.Log($"BattleMenuManager: OnAbilitySelected() called with index {abilityIndex}.");
        if (state != CombatState.PLAYERTURN) return;

        if (abilityIndex >= 0 && abilityIndex < abilityNames.Length)
        {
            string chosenAbility = abilityNames[abilityIndex];
            Debug.Log($"Player selected: {chosenAbility}");

            // Update your combat log
            UpdateCombatLog($"Player used {chosenAbility}!");
            // Return to main menu or proceed to combat turn resolution should Player skip Actions
            OpenCombatMenu();
        }
    }

    public void OnFleeButtonClicked()
    {
        Debug.Log("BattleMenuManager: OnFleeButtonClicked() called.");
        if (state != CombatState.PLAYERTURN) return;

        if (activeEnemy != null && activeEnemy.getIsBoss())
        {
            UpdateCombatLog("You cannot flee from a boss!");
            return;
        }

        UpdateCombatLog("Player rolled a d20 and failed the flee check!"); // Add random chance check, discuss what that chance should be
        StartCoroutine(ProcessEnemyTurnAfterAction());
    }

    private void PopulateInventoryUI()
    {
        Debug.Log("BattleMenuManager: PopulateInventoryUI() called.");
        if (itemButtonContainer == null || itemButtonPrefab == null)
        {
            Debug.LogError("BattleMenuManager: ItemButtonContainer or ItemButtonPrefab is unassigned!");
            return;
        }
        // Clear out old buttons if reloading inventory
        foreach (Transform child in itemButtonContainer)
        {
            Destroy(child.gameObject);
        }

        // Instantiate a button for each item in the player's inventory
        foreach (string itemName in playerInventory)
        {
            GameObject itemButtonObj = Instantiate(itemButtonPrefab, itemButtonContainer);
            TextMeshProUGUI buttonText = itemButtonObj.GetComponentInChildren<TextMeshProUGUI>();

            if (buttonText != null)
            {
                buttonText.text = itemName;
            }

            // Add click listener dynamically
            UnityEngine.UI.Button btn = itemButtonObj.GetComponent<UnityEngine.UI.Button>();
            string capturedItemName = itemName; // Prevent closure issues
            btn.onClick.AddListener(() => UseItem(capturedItemName));
        }
    }


    private void UseItem(string itemName)
    {
        Debug.Log($"BattleMenuManager: UseItem() called for item: {itemName}");
        if (state != CombatState.PLAYERTURN) return;

        UpdateCombatLog($"Player used item: {itemName}!");
        endAndHealthScript.UpdateUI();
        playerInventory.Remove(itemName); // Remove item from inventory
        OpenCombatMenu();
    }

    private IEnumerator ProcessEnemyTurnAfterAction()
    {
        Debug.Log("BattleMenuManager: ProcessEnemyTurnAfterAction() started.");

        if (activeEnemy == null) // Safety check for null reference
        {
            Debug.LogError("BattleMenuManager: 'activeEnemy' is null! Please assign an Enemy object in the Inspector.");
            yield break;
        }

        CloseAllSubmenus();
        state = CombatState.ENEMYTURN;

        yield return new WaitForSeconds(1.5f);

        //TODO: Calculate damage using player.getDefense(), checking if defending, which then factors in the multiplier
        // 1. Enemy "Free Action" / Pattern Phase
        string enemyPattern = activeEnemy.getAttackPattern();
        UpdateCombatLog($"Enemy adopts a '{enemyPattern}' stance, preparing its move...");
        yield return new WaitForSeconds(1.5f);

        // 2. Enemy Attack Execution using your dmgCalc framework
        int enemyAtk = activeEnemy.getAttack();
        int playerDef = player.getDefense();

        // Apply player's defense multiplier if they chose Defend (1.50x)
        if (isPlayerDefending)
        {
            playerDef = Mathf.RoundToInt(playerDef * (float)defenseMultiplier);
            UpdateCombatLog("Player's defense brace mitigates incoming pressure!");
        }

        // Roll for enemy critical hit
        bool rollCrit = UnityEngine.Random.value <= activeEnemy.getCritRate();
        int finalDamage = 0;

        if (rollCrit)
        {
            UpdateCombatLog("The enemy lands a critical strike!");
            finalDamage = critDmgCalc(enemyAtk, playerDef, activeEnemy.getCritDamage());
    }
        else
        {
            finalDamage = dmgCalc(enemyAtk, playerDef);
    }

        // 3. Apply damage to player via Entity.takeDamage()
        player.takeDamage(finalDamage);
    UpdateCombatLog($"Enemy hits player for {finalDamage} damage! Player HP: {player.getCurrentHealth()}");

        // Reset player defense buff for the next round
        isPlayerDefending = false;

        endAndHealthScript.UpdateUI();

        // 4. Check win/loss state
        if (player.getCurrentHealth() <= 0)
        {
            state = CombatState.LOST;
            UpdateCombatLog("Player has been defeated...");
            if (endAndHealthScript != null)
            {
                endAndHealthScript.gameOver(); 
            }
            yield break;
        }

        yield return new WaitForSeconds(2f);

        state = CombatState.PLAYERTURN;
        PlayerTurn();
    }

    private void CloseAllSubmenus()
    {
        Debug.Log("BattleMenuManager: CloseAllSubmenus() called.");
        if (combatMenu) combatMenu.SetActive(false);
        if (abilitiesSubmenu) abilitiesSubmenu.SetActive(false);
        if (actionsSubmenu) actionsSubmenu.SetActive(false);
        if (itemsSubmenu) itemsSubmenu.SetActive(false);
        if (settingsMenu) settingsMenu.SetActive(false);
    }

    public void UpdateCombatLog(string message)
    {
        Debug.Log($"[Combat Log]: {message}");
        if (logQueue.Count >= maxLogLines)
        {
            logQueue.Dequeue(); // Remove the oldest message
        }

        logQueue.Enqueue(message);

        if (combatLogText != null)
        {
            combatLogText.text = string.Join("\n", logQueue);
        }
    }



    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (combatMenu != null && combatMenu.activeSelf)
            {
                OpenSettingsMenu();
            } else
            {
                OpenCombatMenu();
            }
        }
    }
}
