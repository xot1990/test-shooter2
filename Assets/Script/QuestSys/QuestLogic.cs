using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestLogic : MonoBehaviour
{
    [SerializeField] private List<QuestData> _questDatas;
    private List<Quest> _quests = new();
    private delegate bool CheckQuest(ref float target,float value);

    private CheckQuest Quest;

    private void Awake()
    {
        foreach (var data in _questDatas)
        {
            _quests.Add(data.CreateQuest());
        }
    }

    private void Start()
    {
        QuestEventBus.GetFillQuests(_quests);
    }

    private void OnEnable()
    {
        QuestEventBus.tickTime += ObserveTimeEvent;
        QuestEventBus.enemyDie += ObserveKillEvent;
    }

    private void OnDisable()
    {
        QuestEventBus.tickTime -= ObserveTimeEvent;
        QuestEventBus.enemyDie -= ObserveKillEvent;
    }

    private void ObserveTimeEvent()
    {
        foreach (var q in _quests)
        {
            if (q.questType == global::Quest.QuestType.Time)
            {
                q.Done(null);
            }
        }
    }
    
    private void ObserveKillEvent(Enemy enemy)
    {
        foreach (var q in _quests)
        {
            if (q.questType == global::Quest.QuestType.Kill)
            {
                Debug.Log(enemy);
                q.Done(enemy);
            }
        }
    }
}
