using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InitChestItem : MonoBehaviour
{
    public StandItem standItem;

    [HideInInspector]
    public Text dialog_text;
    [HideInInspector]
    public Canvas dialog_window;



    void Start()
    {
        dialog_text = GameObject.FindGameObjectWithTag("dialog_text")
            .GetComponent<Text>();
        dialog_window = GameObject.FindGameObjectWithTag("dialog_window")
            .GetComponent<Canvas>();
        standItem.isItemAdded = false;

    }

}
