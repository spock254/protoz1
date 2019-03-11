using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{

    #region Singleton

    public static Inventory instance;

    void Awake()
    {
        instance = this;
    }

    #endregion

    //public delegate void OnItemChanged();
    //public OnItemChanged onItemChangedCallback;

    public int space = 5;  // Amount of item spaces

    // Our current list of items in the inventory
    public List<Item> items = new List<Item>();
    public int currentItemCount = 0;



    // Add a new item if enough room
    public bool Add(Item item)
    {
        if (item.showInInventory)
        {
            if (items.Count >= space && SetInNullElement() == -1)
            {
                Debug.Log("Not enough room.");
                return false;
            }
            if (currentItemCount == items.Count - 1)
            {
                Debug.Log("d");
                currentItemCount = SetInNullElement();
                items.Insert(currentItemCount,item);
            }
            else
                items.Add(item);
            Debug.Log(currentItemCount);
            UIInventory.instance.AddToUiInventorySlot(item, currentItemCount);
            currentItemCount++;

            
            //if (onItemChangedCallback != null)
            //   onItemChangedCallback.Invoke();

            return true;
        }
        return false;        
    }

    // Remove an item
    public void Remove(Item item)
    {
        items.Remove(item);
        currentItemCount--;

        //if (onItemChangedCallback != null)
        //    onItemChangedCallback.Invoke();
    }
    private int SetInNullElement()
    {
        int index = -1;
        foreach (Item item in items)
        {
            index++;
            if (item == null)
                break;
        }
        return index;
    }
}