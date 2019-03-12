using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "New Item", menuName = "Inventory/Dropable_Item")]
public class DropableItem : Item
{

    public override void Use()
    {
        Debug.Log("DROP");
        
    }
    public override void Drop()
    {
        base.Drop();
    }
}
