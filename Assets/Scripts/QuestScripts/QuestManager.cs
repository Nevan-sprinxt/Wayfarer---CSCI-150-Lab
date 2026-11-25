using System.Collections.Generic;
using UnityEngine;

public class QuestManager : MonoBehaviour
{

    public List<QuestProgress> activeQuest = new();

    public void UpdateObjective(string questID, string objectiveID, int amount)
    {
        QuestProgress quest = activeQuest.Find(q => q.questID == questID);

        if (quest == null || quest.isCompleted)
            return;

        ObjectiveProgress objective = quest.objectives.Find(o => o.objectiveID == objectiveID);

        if (objective == null)
            return;

        objective.currentAmount += amount;

        QuestObjective questObj = System.Array.Find(quest.questData.objectives, q2 => q2.objectiveID == objective.objectiveID);

        if(objective.currentAmount >= questObj.requiredAmount)
        {
            objective.setObjCompleted();
        }

    }

    public void UpdateAllQuest(string objectiveID, int amount)
    {
        foreach (QuestProgress quest in activeQuest)
        {
            UpdateObjective(quest.questID, objectiveID, amount);
        }
    }

}
