using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestKill : Quest
{
    public Enemy target;

    public QuestKill(QuestDataKills D) : base(D)
    {
        questType = QuestType.Kill;
        goal = D.kills;
        target = D.enemyType;
    }
    
    public override void Done(Enemy T)
    {
        if(target.GetType() == T.GetType())
        {
            progress++;
        }
        
        base.Done(T);
    }
}
