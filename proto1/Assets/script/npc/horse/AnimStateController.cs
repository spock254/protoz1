using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimStateController : MonoBehaviour
{
    private Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        animator.SetBool("smoking", false);
    }

    // Update is called once per frame
    void Update()
    {
        // test
        if (Input.GetKeyDown(KeyCode.Z))
        {
            foreach (Item item in Inventory.instance.items)
            {
                Debug.Log(item.name);
            }
        }
        if (Input.GetKeyDown(KeyCode.V))
        {
            int index = -1;
            for (int i = 0; i < Inventory.instance.items.Count; i++)
            {
                if (Inventory.instance.items[i].name.Equals("cigarettes"))
                {
                    //Inventory.instance.RemoveByIndex(i);
                    index = i;
                }
            }
            if (index != -1)
                Inventory.instance.RemoveByIndex(index);
        }
    }
}
