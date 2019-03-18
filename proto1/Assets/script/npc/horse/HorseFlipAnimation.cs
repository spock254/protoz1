using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HorseFlipAnimation : MonoBehaviour
{
    public CircleCollider2D left_collider;
    public CircleCollider2D right_collider;

    public Collider2D player_collider;
    private Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        
        if (other.CompareTag(player_collider.tag) && left_collider.IsTouching(player_collider))
        {
            animator.SetBool("left",true);
        }
        else if (other.CompareTag(player_collider.tag) && right_collider.IsTouching(player_collider))
        {
            animator.SetBool("right", true);
        }
    }
    void OnTriggerExit2D(Collider2D other)
    {
        
        if (other.CompareTag(player_collider.tag) && !left_collider.IsTouching(player_collider))
        {
            animator.SetBool("left", false);
            //Debug.Log("LEFT");


        }
        if (other.CompareTag(player_collider.tag) && !right_collider.IsTouching(player_collider))
        {
            animator.SetBool("right", false);
            //Debug.Log("RIGHT");

        }
    }

    private void Update()
    {
       // ColliderDistance2D left_dist = left_collider.Distance(player_collider);
        //ColliderDistance2D right_dist = right_collider.Distance(player_collider);
       // if (left_dist.)
    }

}
