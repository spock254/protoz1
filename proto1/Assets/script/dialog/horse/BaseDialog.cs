
using UnityEngine;
using VIDE_Data;
using UnityEngine.UI;
using System.Collections.Generic;
using System.Collections;

public class BaseDialog : MonoBehaviour
{
    protected GameObject container_NPC;
    protected Text text_NPC;
    protected Image image_NPC;

    protected bool dialog_over = false;
    protected int currentDialogState;

    protected void Start()
    {
        container_NPC = GameObject.FindGameObjectWithTag("dialog_window");
        text_NPC = GameObject.FindGameObjectWithTag("dialog_text").GetComponent<Text>();
        image_NPC = GameObject.FindGameObjectWithTag("dialog_image").GetComponent<Image>();
        container_NPC.SetActive(false);
        text_NPC.text = "";
        currentDialogState = HorseState.GET_STATE();

    }



    protected void Begin()
    {
        PlayerMovements.isPlayerInputEnable = false;
        VD.OnNodeChange += UpdateUI;
        VD.OnEnd += End;
        VD.BeginDialogue(GetComponent<VIDE_Assign>());
        VD.SetNode(HorseState.GET_STATE());
    }

    void UpdateUI(VD.NodeData data)
    {
        if (data.isPlayer)
        {

        }
        else
        {

            container_NPC.SetActive(true);
            //text_NPC.text = data.comments[data.commentIndex];
            //StartCoroutine(AnimateText(data.comments[data.commentIndex])); // anim dialog
            text_NPC.text = data.comments[data.commentIndex];
            //image_NPC.sprite = data.sprites[data.commentIndex];


        }
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (VD.isActive)
            {
                text_NPC.text = "";
                VD.Next();
                
            }
        }
    }
    void End(VD.NodeData data)
    {
        PlayerMovements.isPlayerInputEnable = true;
        dialog_over = true;
        container_NPC.SetActive(false);
        VD.OnNodeChange -= UpdateUI;
        VD.OnEnd -= End;
        VD.EndDialogue();
        text_NPC.text = ""; // !

    }
    void OnDisable()
    {
        if (container_NPC != null)
            End(null);
    }
   /* IEnumerator AnimateText(string strComplete)
    {
        int i = 0;
        text_NPC.text = "";
        while (i < strComplete.Length)
        {
            text_NPC.text += strComplete[i];
            i++;
            yield return new WaitForSeconds(0.03F);
        }
    }
    */
}
