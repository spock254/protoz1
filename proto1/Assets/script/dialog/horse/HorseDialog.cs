using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VIDE_Data;
using UnityEngine.UI;

public class HorseDialog : BaseDialog
{
    //test
    CameraController cameraController;
    GameObject player_target;

    private void Start()
    {
        base.Start();
        cameraController = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<CameraController>();
        player_target = GameObject.FindGameObjectWithTag("Player");
    }

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
        cameraController.target = this.gameObject;

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
    private void OnTriggerExit2D(Collider2D collision)
    {
        cameraController.target = player_target;
    }
}
