using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeforeEntere : MonoBehaviour
{
    public float timeLeft;
    public Color targetColor;
    Camera mainCamera;

    
    public BoxCollider2D[] boxCollider2Ds;
    bool isCollidersEnabled = false;

    private void Start()
    {
        mainCamera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        foreach (BoxCollider2D item in boxCollider2Ds)
        {
            item.enabled = false;
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (timeLeft > Time.deltaTime)
        {

            // transition in progress
            // calculate interpolated color
            mainCamera.backgroundColor = Color.Lerp(mainCamera.backgroundColor, targetColor, Time.deltaTime / timeLeft);

            // update the timer
            timeLeft -= Time.deltaTime;
        }
        if (!isCollidersEnabled)
        {
            isCollidersEnabled = true;
            foreach (BoxCollider2D item in boxCollider2Ds)
            {
                item.enabled = true;
            }
        }
    }
}
