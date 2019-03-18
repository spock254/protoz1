using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationAgeSet : MonoBehaviour
{
    private static Animator animator;
    private const float CURRENT_LAYER_WEIGHT = 2f;
    private static int current_layer_index = 0;

    private bool ageChanged = false;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame


    private static void SetLayer(int index)
    {
        //animator.SetLayerWeight(index, 0);
        //index += 1;
        animator.SetLayerWeight(index, CURRENT_LAYER_WEIGHT);
    }
    public static void AgeSwitcher()
    {
        /*
        if (PlayerManager.Stats.Age.StatValue <= 20)
        {
            SetLayer(0);
        }
        else if (PlayerManager.Stats.Age.StatValue <= 30)
        {
            SetLayer(1);
        }
        else if (PlayerManager.Stats.Age.StatValue <= 40)
        {
            SetLayer(2);
        }
        else if (PlayerManager.Stats.Age.StatValue <= 50)
        {
            SetLayer(3);
        }
        else if (PlayerManager.Stats.Age.StatValue <= 60)
        {
            SetLayer(4);
        }
        else if (PlayerManager.Stats.Age.StatValue <= 70)
        {
            SetLayer(5);
        }
        */
    }
}
