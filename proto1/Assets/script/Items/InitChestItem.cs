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
    [HideInInspector]
    public Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        dialog_text = GameObject.FindGameObjectWithTag("dialog_text")
            .GetComponent<Text>();
        dialog_window = GameObject.FindGameObjectWithTag("dialog_window")
            .GetComponent<Canvas>();
        standItem.isItemAdded = false;

        animator = GetComponent<Animator>();
    }
}
