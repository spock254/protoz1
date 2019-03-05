using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimTest : MonoBehaviour
{
    private Animator animator;

    private bool up, down, left, right;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        float moveY = Input.GetAxisRaw("Vertical");
        float moveX = Input.GetAxisRaw("Horizontal");
        AnimController(moveX,moveY);
        AnimSet();

    }

    private void AnimController(float x,float y)
    {
        left = (x < 0) ? true : false;
        right = (x > 0) ? true : false; 
        up = (y > 0) ? true : false;
        down = (y < 0) ? true : false;
    }
    private void AnimSet()
    {

        animator.SetBool("up", up);
        animator.SetBool("down", down);
        animator.SetBool("left", left);
        animator.SetBool("right", right);


    }

    
}
