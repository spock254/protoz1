using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseQuest : MonoBehaviour
{
    public bool isQuestPass = false;
    public bool isQuestCanceld = false;

    public virtual void QuestChecking()
    {
        
    }
}
