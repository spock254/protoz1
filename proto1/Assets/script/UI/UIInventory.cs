using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using System.Linq;

public class UIInventory : MonoBehaviour
{
    public static UIInventory instance; // Singleton
    // Start is called before the first frame update
    private Image[] sprites_items;

    public Sprite default_sprite;
    public GameObject inventory_container;

    // window slots data
    private Image[] window_slots;

    public TextMeshProUGUI item_name;

    public EventSystem eventSystem;
    public GameObject selectedObject;
    //public int currentSlot = 0;
    private bool buttonSelected;
    private bool inventoryActive = false;

    public Text actionButtonsText;

    private int current_tem_index;

    private void Awake()
    {
        instance = this; // Singleton
        sprites_items = new Image[5];

         sprites_items[0] = (GameObject.FindGameObjectWithTag("slot_1")
             .GetComponent<Image>());
         sprites_items[1] = (GameObject.FindGameObjectWithTag("slot_2")
             .GetComponent<Image>());
         sprites_items[2] = (GameObject.FindGameObjectWithTag("slot_3")
             .GetComponent<Image>());
         sprites_items[3] = (GameObject.FindGameObjectWithTag("slot_4")
             .GetComponent<Image>());
         sprites_items[4] = (GameObject.FindGameObjectWithTag("slot_5")
             .GetComponent<Image>());

        window_slots = new Image[5];
        window_slots[0] = GameObject.FindGameObjectWithTag("window_slot_1")
            .GetComponent<Image>();
        window_slots[1] = GameObject.FindGameObjectWithTag("window_slot_2")
            .GetComponent<Image>();
        window_slots[2] = GameObject.FindGameObjectWithTag("window_slot_3")
            .GetComponent<Image>();
        window_slots[3] = GameObject.FindGameObjectWithTag("window_slot_4")
            .GetComponent<Image>();
        window_slots[4] = GameObject.FindGameObjectWithTag("window_slot_5")
            .GetComponent<Image>();
        item_name.text = "";

        inventory_container.SetActive(false);
        actionButtonsText.text = "";
        
    }


    void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.I))
        {
            inventoryActive = !inventoryActive;
            inventory_container.SetActive(inventoryActive);
            PlayerMovements.isPlayerInputEnable = !PlayerMovements.isPlayerInputEnable;
            
        }

        if (Input.GetAxisRaw("Horizontal") != 0 && buttonSelected == false && inventoryActive)
        {
            eventSystem.SetSelectedGameObject(selectedObject);
            buttonSelected = true;
            
            
        }

        #region player action item menu
        // if item is usable, opening 2 actions
        if (actionButtonsText.text.Equals(UIContent.ACTION_BUTTON_CONTENT_USE_DROP))
        {
            item_name.text = Inventory.instance.items[current_tem_index].name;
            if (Input.GetKeyDown(KeyCode.E))
            {
                Inventory.instance.items[current_tem_index].Use();
                DeleteWhenItemUsed(current_tem_index);
                actionButtonsText.text = "";
                eventSystem.SetSelectedGameObject(selectedObject);
                item_name.text = "";
            }
            else if (Input.GetKeyDown(KeyCode.X))
            {
                Inventory.instance.items[current_tem_index].Drop();
                DeleteWhenItemUsed(current_tem_index);
                actionButtonsText.text = "";
                eventSystem.SetSelectedGameObject(selectedObject);
                item_name.text = "";
            }
            else if (Input.GetKeyDown(KeyCode.Escape))
            {
                actionButtonsText.text = "";
                eventSystem.SetSelectedGameObject(selectedObject);
                item_name.text = "";
            }
            
        }
        // if item dropable opening 1 action
        else if (actionButtonsText.text.Equals(UIContent.ACTION_BUTTON_CONTENT_DROP))
        {
            item_name.text = Inventory.instance.items[current_tem_index].name;
            if (Input.GetKeyDown(KeyCode.X))
            {
                Inventory.instance.items[current_tem_index].Drop();
                DeleteWhenItemUsed(current_tem_index);
                actionButtonsText.text = "";
                eventSystem.SetSelectedGameObject(selectedObject);
                item_name.text = "";
            }
            else if (Input.GetKeyDown(KeyCode.Escape))
            {
                actionButtonsText.text = "";
                eventSystem.SetSelectedGameObject(selectedObject);
                item_name.text = "";
            }
           
        }
        #endregion
    }
    // BUTTONS ACTIONS
    public void Click(int item_index)
    {
        if (Inventory.instance.items[item_index])
        {
            eventSystem.SetSelectedGameObject(null);
            if (!Inventory.instance.items[item_index].isDropable)
            {
                actionButtonsText.text = UIContent.ACTION_BUTTON_CONTENT_USE_DROP;
            }
            else if (Inventory.instance.items[item_index].isDropable)
            {
                actionButtonsText.text = UIContent.ACTION_BUTTON_CONTENT_DROP;
            }
            current_tem_index = item_index;
        }
        
    }
    private void DeleteWhenItemUsed(int item_index)
    {
        Inventory.instance.RemoveByIndex(item_index);
    }
    //TODO optimization
    public void CopyItemsToUIPanel(List<Item> items)
    {
        foreach (Image item_icon in sprites_items)
        {
            item_icon.sprite = default_sprite;
        }
        for (int i = 0; i < items.Count; i++)
            if (items[i] != null)
                sprites_items[i].sprite = items[i].icon;
    } 
    private void DisablePlayerInput()
    {
        PlayerMovements.isPlayerInputEnable = false;
        eventSystem.SetSelectedGameObject(null);
    }
    private void EnablePlayerInput()
    {
        PlayerMovements.isPlayerInputEnable = true;
        eventSystem.SetSelectedGameObject(selectedObject);
    }

}
