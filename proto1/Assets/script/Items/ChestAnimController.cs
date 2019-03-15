using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestAnimController : MonoBehaviour
{

    private ItemPickup itemPickup;
    private Animator animator;

    float time;
    RuntimeAnimatorController ac;
    void Start()
    {
        itemPickup = GetComponent<ItemPickup>();
        animator = GetComponent<Animator>();
        ac = animator.runtimeAnimatorController;
        time = getOpenTime();
    }

    private void Update()
    {
        if (itemPickup.isPickedUp)
        {
            animator.SetTrigger("open");
            //time = getOpenTime();
            

        }
        else { animator.ResetTrigger("open"); }

       
    }

    private float getOpenTime()
    {
        return ac.animationClips[0].length;
    }
    /*
    private float getAnimTime(string anim_name)
    {
        float _time = 0;
        for (int i = 0; i < ac.animationClips.Length; i++)                 //For all animations
        {
            if (ac.animationClips[i].name == anim_name)        //If it has the same name as your clip
            {
                _time = ac.animationClips[i].length;
            }
        }
        return _time;
    }
    */

}
