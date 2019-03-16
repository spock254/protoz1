using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
[CreateAssetMenu(fileName = "New Item", menuName = "Inventory/Stand_Item")]
public class StandItem : Item
{
    public Item inner_item;
    public bool isItemAdded = false;

    public virtual void Use()
    {
        base.Use();

        if (!inner_item)
        {
            Debug.Log(base.name +" is empty");
        }
        else if (inner_item && !isItemAdded)
        {
            isItemAdded = Inventory.instance.Add(inner_item);
            //inner_item = null;
        }
        
        Debug.Log(isItemAdded);

       
    }
    public virtual void Drop()
    {

    }
}
