using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class Quest
{
    public enum QuestType
    {
        Time,
        Kill
    }
    
    public int progress;
    public int goal;
    public QuestType questType;

    public Quest(QuestData D) { }
    
    public virtual void Done(Enemy T)
    {
        QuestEventBus.GetUpdateQuestUi();
        CheckDone();
    }

    private void CheckDone()
    {
        if(progress >= goal)
            QuestEventBus.GetDoneQuest(this);
    }
}
