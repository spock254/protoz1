using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VIDE_Data;
using UnityEngine.UI;

public class HorseDialog : BaseDialog
{


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (VD.isActive)
            {
                VD.Next();
            }
        }
        

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (currentDialogState != DialogState.HorseDialogState.CURRENT_DIALOG_STATE)
            dialog_over = false;
        if (!VD.isActive && !base.dialog_over)
        {
            Begin();
        }
    }
    
    
}
