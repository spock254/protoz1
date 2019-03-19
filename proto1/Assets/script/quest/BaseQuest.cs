using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseQuest : MonoBehaviour
{
    public string Name;
    public bool isQuestPass = false;
    public bool isQuestCanceld = false;
    public bool item_been_in_invetory = false;

    public virtual void QuestChecking()
    {
        
    }
}
