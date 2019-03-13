using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VIDE_Data;
using UnityEngine.UI;

public class DialogSystem : MonoBehaviour
{

    public GameObject container_NPC;
    public Text text_NPC;
    public Image image_NPC;

    private void Start()
    {
        container_NPC.SetActive(false);
        text_NPC.text = "";
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.H))
        {
            if (!VD.isActive)
            {
                Begin();
            }
            else
            {
                VD.Next();
            }
        }

    }
    void Begin()
    {
        VD.OnNodeChange += UpdateUI;
        VD.OnEnd += End;
        VD.BeginDialogue(GetComponent<VIDE_Assign>());
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
