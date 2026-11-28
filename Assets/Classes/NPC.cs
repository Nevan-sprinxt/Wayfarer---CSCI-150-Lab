using UnityEngine;
using System.Collections.Generic;
public class NPC
{
    [SerializeField] protected string Name;
    //[SerializeField] protected List<string> Dialogue = new List<string>();
    [SerializeField] protected List<string> Dialogue;
    //Have inventory later

    public string getName()
    {
        return Name;
    }

    public string getDialogue(string start)
    {
        return Dialogue.Find(x => x.StartsWith(start));
    }

    public string getDialogue1()//Placeholder
    {
       // return Dialogue.Find(x => x.StartsWith("N"));
       return Dialogue[0];
    }
}
