﻿using System.Collections;
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
        if (currentDialogState != HorseState.GET_STATE())
        {
            dialog_over = false;
            currentDialogState = HorseState.GET_STATE();
        }
        if (!VD.isActive && !dialog_over)
        {
            Begin();
            
        }
    }
}
