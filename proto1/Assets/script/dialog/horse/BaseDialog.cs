
using UnityEngine;
using VIDE_Data;
using UnityEngine.UI;

public class BaseDialog : MonoBehaviour
{
    protected GameObject container_NPC;
    protected Text text_NPC;
    protected Image image_NPC;

    protected bool dialog_over = false;
    protected int currentDialogState;

    private void Start()
    {
        container_NPC = GameObject.FindGameObjectWithTag("dialog_window");
        text_NPC = GameObject.FindGameObjectWithTag("dialog_text").GetComponent<Text>();
        image_NPC = GameObject.FindGameObjectWithTag("dialog_image").GetComponent<Image>();
        container_NPC.SetActive(false);
        text_NPC.text = "";
        currentDialogState = DialogState.HorseDialogState.CURRENT_DIALOG_STATE;

    }
    protected void Begin()
    {
        PlayerMovements.isPlayerInputEnable = false;
        VD.OnNodeChange += UpdateUI;
        VD.OnEnd += End;
        VD.BeginDialogue(GetComponent<VIDE_Assign>());
        VD.SetNode(DialogState.HorseDialogState.CURRENT_DIALOG_STATE);
    }

    protected void UpdateUI(VD.NodeData data)
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
    protected void End(VD.NodeData data)
    {
        PlayerMovements.isPlayerInputEnable = true;
        dialog_over = true;
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
