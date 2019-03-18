using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetItemQuestDetection : MonoBehaviour
{
    public GetItemQuest itemQuest;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        itemQuest.item_been_in_invetory = itemQuest.ItemDetection();
    }
}
