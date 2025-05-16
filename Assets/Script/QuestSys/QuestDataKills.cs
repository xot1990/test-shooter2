using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu]
public class QuestDataKills : QuestData
{
    public int kills;
    public Enemy enemyType;
    
    public override Quest CreateQuest()
    {
        return new QuestKill(this);
    }
}
