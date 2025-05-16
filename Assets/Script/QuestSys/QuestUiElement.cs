using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Animator))]
public class QuestUiElement : MonoBehaviour
{
    [SerializeField] private Image progressBar;
    [SerializeField] private Image questIcon;
    [SerializeField] private List<Sprite> Icons;
    
    private Quest quest;
    private Animator _animator;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    private void OnEnable()
    {
        QuestEventBus.updateQuestUi += UpdateProgress;
        QuestEventBus.doneQuest += DoneQuest;
    }

    private void OnDisable()
    {
        QuestEventBus.updateQuestUi -= UpdateProgress;
        QuestEventBus.doneQuest -= DoneQuest;
    }

    public void FillElement(Quest Q)
    {
        quest = Q;
        
        switch (Q.questType)
        {
            case Quest.QuestType.Kill:
                questIcon.sprite = Icons[0];
                break;
            case Quest.QuestType.Time:
                questIcon.sprite = Icons[1];
                break;
            default:
                questIcon.sprite = Icons[0];
                break;
        }
        
        UpdateProgress();
    }

    private void UpdateProgress()
    {
        progressBar.fillAmount = quest.goal / (float)quest.progress;
    }

    private void DoneQuest(Quest Q)
    {
        if(Q == quest)
            _animator.Play("Done");
    }

    public void DestroyObj()
    {
        Destroy(gameObject);
    }
}
