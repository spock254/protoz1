using UnityEngine;

/* The base item class. All items should derive from this. */

[CreateAssetMenu(fileName = "New Item", menuName = "Inventory/Item")]
public class Item : ScriptableObject
{

    public Transform prefab;                // spawn item prefab
    new public string name = "New Item";    // Name of the item
    public Sprite icon = null;              // Item icon
    public bool showInInventory = true;
    public bool isDropable = false;         // if posable just drop not to use

    [HideInInspector]
    public int pickTimeID;
    // Called when the item is pressed in the inventory
    public virtual void Use()
    {

    }
    public virtual void Drop()
    {
        Vector3 playerPosition = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>().position;
        Instantiate(prefab, playerPosition, Quaternion.identity);
    }

    // Call this method to remove the item from inventory
    public void RemoveFromInventory()
    {
        Inventory.instance.Remove(this);
    }

}