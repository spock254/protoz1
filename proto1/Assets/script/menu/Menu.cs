using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu : MonoBehaviour
{
    public Transform p1, p2, p3, p4;
    public void StartScene()
    {
        AnimationAgeSet.i++;
        if (AnimationAgeSet.i == 8)
        Application.LoadLevel(1);
    }
    private void Update()
    {
        if (p1.position.x < transform.position.x)
            transform.position = p2.position;
        if (p2.transform.position.x < transform.position.x)
            transform.position = p1.position;
        if (transform.position.y > p3.transform.position.y)
            transform.position = p4.position;
        if (transform.position.y > p4.transform.position.y)
            transform.position = p3.position;
    }
}
