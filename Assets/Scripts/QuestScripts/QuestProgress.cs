using System;
using System.Collections.Generic;

[Serializable]
public class QuestProgress
{
    public QuestData questData;
    public string questID;
    public bool isReadyToTurnIn;
    public bool isCompleted;
    public List<ObjectiveProgress> objectives = new();
}

[Serializable]
public class ObjectiveProgress
{
    public string objectiveID;
    public int currentAmount;
    private bool completed;

    public void setObjCompleted()
    {
        completed = true;
    }

    public bool getObjCompleted()
    {
        return completed;
    }
}