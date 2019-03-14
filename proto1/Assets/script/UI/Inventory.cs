using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

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
            if (items.Count < space)
            {
                items.Add(item);
                RemoveAllNullItems();
                UIInventory.instance.CopyItemsToUIPanel(items);
                Debug.Log(items.Count);
                return true;
            }
            else if (items.Count >= space)
            {
                Debug.Log("Not enough room.");
                return false;
            }
        }
        else if (!item.showInInventory)
        {
            Debug.Log("zzz");
            return true;// ????
        }
        return false;        
    }

    // Remove an item
    public void Remove(Item item)
    {
        items.Remove(item);
        currentItemCount--;
    }
    public void RemoveByIndex(int index)
    {
        items[index] = null;
        RemoveAllNullItems();
        UIInventory.instance.CopyItemsToUIPanel(items);
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
    private void RemoveAllNullItems()
    {
        items.RemoveAll(x => x == null);
    }
}