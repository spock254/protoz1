using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VIDE_Data;
using UnityEngine.UI;

public class HorseDialog : MonoBehaviour
{

    private GameObject container_NPC;
    private Text text_NPC;
    private Image image_NPC;


    private void Start()
    {
        container_NPC = GameObject.FindGameObjectWithTag("dialog_window");
        text_NPC = GameObject.FindGameObjectWithTag("dialog_text").GetComponent<Text>();
        image_NPC = GameObject.FindGameObjectWithTag("dialog_image").GetComponent<Image>();
        container_NPC.SetActive(false);
        text_NPC.text = "";

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
        if (!VD.isActive)
        {
            Begin();
        }
    }
    
    void Begin()
    {
        
        VD.OnNodeChange += UpdateUI;
        VD.OnEnd += End;
        VD.BeginDialogue(GetComponent<VIDE_Assign>());
        VD.SetNode(DialogState.HorseDialogState.CURRENT_DIALOG_STATE);
    }

    void UpdateUI(VD.NodeData data)
    {
        if (data.isPlayer)
        {

        }
        else
        {
            
                container_NPC.SetActive(true);
                text_NPC.text = data.comments[data.commentIndex];
                image_NPC.sprite = data.sprites[data.commentIndex];
            

        }
    }
    void End(VD.NodeData data)
    {
        container_NPC.SetActive(false);
        VD.OnNodeChange -= UpdateUI;
        VD.OnEnd -= End;
        VD.EndDialogue();
    }
    void OnDisable()
    {
        if (container_NPC != null)
            End(null);
    }
}
