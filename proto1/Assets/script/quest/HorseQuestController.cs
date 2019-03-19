using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HorseQuestController : BaseQuestController
{
    private BaseQuest cigaretsQuest;
    private bool isActive_cigaretsQuest = true; // для избежания повторного прогона квеста 
                                                // и изменения состояния
    
    protected override void Start()
    {
        base.Start();
        foreach (BaseQuest quest in base.quest)
        {
            if (quest.Name.Equals("cigarets"))
                cigaretsQuest = quest;
        }
    }
    public override void Action()
    {
        base.Action();
        if (isActive_cigaretsQuest)
        {
            if (cigaretsQuest.isQuestPass && !cigaretsQuest.isQuestCanceld)
                HorseState.SET_STATE(HorseState.State.CIGARETS);
            else if (!cigaretsQuest.isQuestPass && cigaretsQuest.isQuestCanceld)
                HorseState.SET_STATE(HorseState.State.NO_CIGARETS);
            npcMemory.AddQuestMemory(cigaretsQuest);
            
        }

    }
    private bool _isTriggert = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!_isTriggert && cigaretsQuest.item_been_in_invetory && isActive_cigaretsQuest)
        {
            cigaretsQuest.QuestChecking();
            Debug.Log("item_been_in_invetory = " + cigaretsQuest.item_been_in_invetory + "" +
        "|||" + "isQuestPass = " + cigaretsQuest.isQuestPass +
        "|||" + "isQuestCanceld = " + cigaretsQuest.isQuestCanceld);
            _isTriggert = true;
            Action();
            isActive_cigaretsQuest = false;
        }

    }
    /*
    private void Update()
    {
        if (cigaretsQuest.isQuestPass)
            HorseState.SET_STATE(HorseState.State.CIGARETS);
        else if (cigaretsQuest.isQuestCanceld)
            HorseState.SET_STATE(HorseState.State.NO_CIGARETS);
    }
    */
}
