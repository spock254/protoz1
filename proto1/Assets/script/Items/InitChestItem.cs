using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InitChestItem : MonoBehaviour
{
    public StandItem standItem;

    void Start()
    {
        standItem.isItemAdded = false;
    }

}
