using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationAgeSet : MonoBehaviour
{
    private Animator animator;
    private const float CURRENT_LAYER_WEIGHT = 2f;
    private int current_layer_index = 0;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
            SetLayer();
    }

    private void SetLayer()
    {
        animator.SetLayerWeight(current_layer_index, 0);
        current_layer_index += 1;
        animator.SetLayerWeight(current_layer_index, CURRENT_LAYER_WEIGHT);
    }
}
