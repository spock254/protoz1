using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HorseQuestController : BaseQuestController
{
    private void Update()
    {
        if (base.quest.isQuestPass)
        {
            DialogState.HorseDialogState.CURRENT_DIALOG_STATE = 1;
            Debug.Log(base.quest.isQuestPass);
        }
    }
}
