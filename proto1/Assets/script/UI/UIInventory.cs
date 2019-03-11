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
        item_name.text = "Ds";

        inventory_container.SetActive(false);
    }


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            inventoryActive = !inventoryActive;
            inventory_container.SetActive(inventoryActive);
        }

        
        if (Input.GetAxisRaw("Horizontal") != 0 && buttonSelected == false && inventoryActive)
        {
            eventSystem.SetSelectedGameObject(selectedObject);
            buttonSelected = true;
            
        }
    }
    public void AddToUiInventorySlot(Item item,int currentItemCount)
    {
        sprites_items[currentItemCount].sprite = item.icon;
    }

    private void OnDisable()
    {
        buttonSelected = false;
    }



    public void Click(int item_index)
    {
        Debug.Log(item_index);
        if (Inventory.instance.items[item_index])
        {
            Inventory.instance.items[item_index].Use();
            Inventory.instance.items[item_index] = null;
            sprites_items[item_index].sprite = default_sprite;

        }
        
    }

}
