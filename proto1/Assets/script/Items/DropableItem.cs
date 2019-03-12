using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "New Item", menuName = "Inventory/Dropable_Item")]
public class DropableItem : Item
{
    public Transform prefab;
    //public Vector2 dropPosition;

    public override void Use()
    {
        Debug.Log("DROP");
        Vector3 playerPosition = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>().position;
        //Vector3 playerPosition = new Vector3(6.70f, 5.31f, 0);
        Instantiate(prefab, playerPosition, Quaternion.identity);
    }
}
