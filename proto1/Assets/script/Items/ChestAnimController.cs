using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestAnimController : MonoBehaviour
{

    private Animator animator;
    private ItemUI itemUI;

    void Start()
    {
        itemUI = GetComponent<ItemUI>();
        animator = GetComponent<Animator>();
    }

    private void Update()
    {

            animator.SetBool("open", itemUI.isOpening);
       
    }

}
