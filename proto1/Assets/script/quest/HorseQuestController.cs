using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HorseQuestController : BaseQuestController
{
    private BaseQuest cigaretsQuest;
    
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
        if (cigaretsQuest.isQuestPass && !cigaretsQuest.isQuestCanceld)
            HorseState.SET_STATE(HorseState.State.CIGARETS);
        else if (!cigaretsQuest.isQuestPass && cigaretsQuest.isQuestCanceld)
            HorseState.SET_STATE(HorseState.State.NO_CIGARETS);
        //npcMemory.AddQuestMemory(cigaretsQuest);

    }

    private void Update()
    {
        if (cigaretsQuest.isQuestPass)
            HorseState.SET_STATE(HorseState.State.CIGARETS);
        else if (cigaretsQuest.isQuestCanceld)
            HorseState.SET_STATE(HorseState.State.NO_CIGARETS);
    }
}
