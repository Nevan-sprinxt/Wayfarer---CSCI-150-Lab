using UnityEngine;
using UnityEngine.UI;

public class UIScript : MonoBehaviour
{

   // public LogicScript dmgCalc;//this will let us grab dmg calcs mid game as long as we tag it

    public int playerHP;
    public Text HPText;

    //void Start()
   // {
       // dmgCalc = GameObect.FindGameObjectWithTag("dmgCalc").GetComponent<LogicScript>();
       //Link once dmgCalc is made
    //}

    [ContextMenu("Lower HP")]//Allows you to test without game events
    public void alterHPText()//Placeholder, should take values from dmg calc in the future
    {//dmgCalc can find us thanks to the tag
        playerHP--;
        HPText.text = playerHP.ToString();
    }

    [ContextMenu("Increase HP")]
    public void alterHPTextUp()//The real version will only need one because we can use 
    {//negative values to heal
        playerHP++;
        HPText.text = playerHP.ToString();
    }
}
