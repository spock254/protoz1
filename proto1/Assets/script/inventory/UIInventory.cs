using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UIInventory : MonoBehaviour
{
    public static UIInventory instance; // Singleton
    // Start is called before the first frame update
    private Image[] sprites_items;


    public Sprite default_sprite;
    public Canvas inventory_container;

    // window slots data
    private Image[] window_slots;



    public EventSystem eventSystem;
    public GameObject selectedObject;
    public int currentSlot = 0;
    private bool buttonSelected;

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

    }


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            inventory_container.enabled = !inventory_container.enabled;
        }

        if (Input.GetAxisRaw("Horizontal") != 0 && buttonSelected == false && inventory_container.enabled)
        {
           // currentSlot += ()Input.GetAxisRaw("Horizontal");
            eventSystem.SetSelectedGameObject(selectedObject);
            currentSlot = getSekectedSlotFromTag(eventSystem
                .currentSelectedGameObject.tag);
            
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
    private int getSekectedSlotFromTag(string tag)
    {
        return Int32.Parse(tag.Substring(tag.Length - 1, 1));
    }
    public void Click1() { Debug.Log("Click_1"); }
    public void Click2() { Debug.Log("Click_2"); }
}
