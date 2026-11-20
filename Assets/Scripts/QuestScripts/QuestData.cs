using UnityEngine;

[CreateAssetMenu(fileName = "Quest", menuName = "Scriptable Objects/Quest")]
public class QuestData : ScriptableObject
{
    public int questID;
    public string questTitle;
    public string questDescription;
    public bool isRepeatable;
    public QuestObjective[] objectives;
}


[System.Serializable]
public class QuestObjective
{
    public string objectiveID;
    public string description;
    public int requiredAmount;
}