using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIInventory : MonoBehaviour
{
    public static UIInventory instance; // Singleton
    // Start is called before the first frame update
    public Image[] sprites_items;
    public Sprite default_sprite;
    public Canvas inventory_container;
    

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

    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            inventory_container.enabled = !inventory_container.enabled;
        }
    }
    public void AddToUiInventorySlot(Item item,int currentItemCount)
    {
        sprites_items[currentItemCount].sprite = item.icon;
    }
}
