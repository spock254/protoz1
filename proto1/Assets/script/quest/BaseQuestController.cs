using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseQuestController : MonoBehaviour
{
    public NPCMemory npcMemory;

    public List<BaseQuest> quest;

    protected virtual void Start()
    {
        quest = new List<BaseQuest>(GetComponentsInChildren<BaseQuest>());
    }

    public virtual void Action()
    {

    }
    

}
