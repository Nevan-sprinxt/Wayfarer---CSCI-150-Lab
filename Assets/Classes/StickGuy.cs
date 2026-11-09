using UnityEngine;
using System.Collections.Generic;

public class StickGuy : NPC
{
   // public Text yapping;

    public StickGuy()
    {
        Name = "Stick Guy";
        Dialogue = new List<string> { "Stick Guy: Niiiiiiceee stiiiick duuuude!"};
         
       //string getDialouge1()
       //{
       // return Dialouge.Find(x => x.StartsWith("N"));
       //}
    }

}
