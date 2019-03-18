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
        if(DialogState.HorseDialogState.CURRENT_DIALOG_STATE == 0)
            animator.SetBool("smoking", false);
        else if(DialogState.HorseDialogState.CURRENT_DIALOG_STATE == 1)
            animator.SetBool("smoking", true);
    }
}
