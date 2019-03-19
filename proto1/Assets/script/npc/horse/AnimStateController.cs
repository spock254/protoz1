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
        if (HorseState.GET_STATE_RAW() == HorseState.State.HELLO)
            animator.SetBool("smoking", false);
        else if (HorseState.GET_STATE_RAW() == HorseState.State.CIGARETS)
            animator.SetBool("smoking", true);
        else if (HorseState.GET_STATE_RAW() == HorseState.State.NO_CIGARETS)
            animator.SetBool("smoking", false);
    }
}
