using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
[CreateAssetMenu(fileName = "New Item", menuName = "Inventory/Stand_Item")]
public class StandItem : Item
{
    public Item inner_item;
    private Text dialog_text;
    private Canvas dialog_window;
    public bool isItemAdded = false;

    public virtual void Use()
    {
        base.Use();

        /*dialog_text = GameObject.FindGameObjectWithTag("dialog_text")
            .GetComponent<Text>();
        dialog_window = GameObject.FindGameObjectWithTag("dialog_window")
            .GetComponent<Canvas>();

        dialog_window.enabled = true;
        dialog_text.enabled = true;

        */
        if (!isItemAdded)
        {
            isItemAdded = Inventory.instance.Add(inner_item);
        }
        
        Debug.Log(isItemAdded);

       
    }
    public virtual void Drop()
    {

    }
}
