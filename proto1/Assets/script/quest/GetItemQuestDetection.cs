using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetItemQuestDetection : MonoBehaviour
{
    public GetItemQuest itemQuest;
    bool _isTriggert = false;
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (!_isTriggert && !itemQuest.item_been_in_invetory)
        {
            itemQuest.item_been_in_invetory = itemQuest.ItemDetection();
            if(itemQuest.item_been_in_invetory)
            _isTriggert = true;
        }
    }
}
