using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class QuestEventBus
{
    public static Action<Enemy> enemyDie;
    public static Action tickTime;
    public static Action<List<Quest>> fillQuests;
    public static Action updateQuestUi;
    public static Action<Quest> doneQuest;

    public static void GetDoneQuest(Quest Q)
    {
        doneQuest?.Invoke(Q);
    }

    public static void GetUpdateQuestUi()
    {
        updateQuestUi?.Invoke();
    }

    public static void GetFillQuests(List<Quest> Q)
    {
        fillQuests?.Invoke(Q);
    }

    public static void GetTickTime()
    {
        tickTime?.Invoke();
    }

    public static void GetEnemyDie(Enemy value)
    {
        enemyDie?.Invoke(value);
    }
}
