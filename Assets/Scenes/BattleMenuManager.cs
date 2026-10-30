//using NUnit.Framework.Constraints;
using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BattleMenuManager : MonoBehaviour
{
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

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        OpenCombatMenu();
        UpdateCombatLog("The enemy has appeared! Quick, respond to the threat!");
    }

    private void OpenSettingsMenu()
    {
        combatMenu.SetActive(false);
        abilitiesSubmenu.SetActive(false);
        actionsSubmenu.SetActive(false);
        itemsSubmenu.SetActive(false);

        if (settingsMenu != null)
        {
            settingsMenu.SetActive(true);
        }
    }

    public void OpenCombatMenu()
    {
        combatMenu.SetActive(true);
        abilitiesSubmenu.SetActive(false);
        actionsSubmenu.SetActive(false);
        itemsSubmenu.SetActive(false);
    }

    public void OpenAbilitiesSubmenu()
    {
        combatMenu.SetActive(false);
        abilitiesSubmenu.SetActive(true);
        actionsSubmenu.SetActive(false);
        itemsSubmenu.SetActive(false);
    }

    public void OpenActionsSubmenu()
    {
        combatMenu.SetActive(false);
        abilitiesSubmenu.SetActive(false);
        actionsSubmenu.SetActive(true);
        itemsSubmenu.SetActive(false);
    }

    public void OpenItemsSubmenu()
    {
        combatMenu.SetActive(false);
        abilitiesSubmenu.SetActive(false);
        actionsSubmenu.SetActive(false);
        itemsSubmenu.SetActive(true);
        PopulateInventoryUI();
    }

    public void OnAttackSelected()
    {
        UpdateCombatLog("Player used Attack!");
        // Add attack state logic 
        // Should also proceed to combat turn resolution
        OpenCombatMenu();
    }

    public void OnDefendSelected()
    {
        UpdateCombatLog("Player braced and chose Defend!");
        // Add defense state logic 
        // Should proceed to combat turn resolution
        OpenCombatMenu();
    }

    // This handles all 4 abilities using an index (0, 1, 2, or 3)
    public void OnAbilitySelected(int abilityIndex)
    {
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
        UpdateCombatLog("Player attempted to flee!");
    }

    private void PopulateInventoryUI()
    {
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
        UpdateCombatLog($"Player used item: {itemName}!");
        playerInventory.Remove(itemName); // Remove item from inventory
        OpenCombatMenu();
    }

    public void UpdateCombatLog(string message)
    {
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
