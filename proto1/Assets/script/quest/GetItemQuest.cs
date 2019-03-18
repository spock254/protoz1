using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetItemQuest : BaseQuest
{
    public Item need_item;
    [HideInInspector]
    public bool item_been_in_invetory = false;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.X))
        {
            Debug.Log("item_been_in_invetory = "+ item_been_in_invetory+"" +
                "|||"+ "isQuestPass = "+ isQuestPass+
                "|||"+ "isQuestCanceld = "+ isQuestCanceld);
        }
        if (Input.GetKeyDown(KeyCode.C))
        {
            QuestChecking();
        }
    }

    public override void QuestChecking()
    {
        base.QuestChecking();
        //if(item_been_in_invetory)
        if (!isQuestCanceld && item_been_in_invetory)
        {
            base.isQuestPass = isItemInInventory();
            if (item_been_in_invetory != base.isQuestPass)
                base.isQuestCanceld = true;
        }
    }
    private bool isItemInInventory()
    {
        int index = -1;
        for (int i = 0; i < Inventory.instance.items.Count; i++)
            if (Inventory.instance.items[i].ID == need_item.ID)
                index = i;
        if (index != -1)
        {
            Inventory.instance.RemoveByIndex(index);
            return true;
        }
        else
            return false;
    }
    public bool ItemDetection()
    {
        int index = -1;
        for (int i = 0; i < Inventory.instance.items.Count; i++)
            if (Inventory.instance.items[i].ID == need_item.ID)
                index = i;
        if (index != -1)
        {
            return true;
        }
        else
            return false;
    }
}
