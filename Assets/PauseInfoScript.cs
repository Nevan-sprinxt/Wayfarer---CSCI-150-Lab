using UnityEngine;
using UnityEngine.UI;

public class PauseInfoScript : MonoBehaviour
{

    public Player wayfarer;
    public Text playerHPText;
    public Text playerMaxHPText;
    public Text currentWeaponText;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerMaxHPText.text = wayfarer.getMaxHealth().ToString();
        playerHPText.text = wayfarer.getCurrentHealth().ToString();
        currentWeaponText.text = wayfarer.GetEquippedWeapon().getWeaponName();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void refresh()//Lets us call this function to update when needed instead of constantly checking for updates
    {
        playerMaxHPText.text = wayfarer.getMaxHealth().ToString();
        playerHPText.text = wayfarer.getCurrentHealth().ToString();
        currentWeaponText.text = wayfarer.GetEquippedWeapon().getWeaponName();
    }
}
