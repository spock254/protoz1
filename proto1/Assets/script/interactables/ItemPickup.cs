using UnityEngine;
using UnityEngine.UI;

public class ItemPickup : Interactable
{

    public Item item;   // Item to put in the inventory if picked up
    [HideInInspector]
    public bool isPickedUp = false;
    // When the player interacts with the item
    public override void Interact()
    {
        base.Interact();
        if (Input.GetKeyDown(KeyCode.Space) && !UIInventory.inventoryActive)
        {
            isPickedUp = true;
            PickUp();
        }
    }

    // Pick up the item
    void PickUp()
    {
        if (item.showInInventory)
        {
            item.pickTimeID = System.Int32.Parse(System.DateTime.UtcNow.ToString("yyHHmmssf"));
            Debug.Log("Picking up " + item.name);
            if (Inventory.instance.Add(item))   // Add to inventory
                Destroy(gameObject);    // Destroy item from scene
        }
        else
        {
            StandItem sitem = (StandItem)item;
            sitem.Use();
        }
    }
}