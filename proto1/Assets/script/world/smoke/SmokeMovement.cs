using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmokeMovement : MonoBehaviour
{
    public float speed1 = 2;
    public float speed2 = 3;
    public float speed3 = 1;

    public GameObject smoke1;
    public GameObject smoke2;
    public GameObject smoke3;

    public Transform smoke_startPoint1;
    public Transform smoke_startPoint2;
    public Transform smoke_startPoint3;

    public Transform smoke_endPoint1;
    public Transform smoke_endPoint2;
    public Transform smoke_endPoint3;



    // Start is called before the first frame update
    void Start()
    {
        smoke1.transform.position = smoke_startPoint1.position;
        smoke2.transform.position = smoke_startPoint2.position;
        smoke3.transform.position = smoke_startPoint3.position;


    }

    // Update is called once per frame
    void Update()
    {
        if (smoke1.transform.position.x != smoke_endPoint1.transform.position.x)
        {
            smoke1.transform.position = Vector2.MoveTowards(smoke1.transform.position, 
                smoke_endPoint1.position, Time.deltaTime * speed1);
        }
        else if (smoke1.transform.position.x == smoke_endPoint1.transform.position.x)
        {
            smoke1.transform.position = smoke_startPoint1.position;
        }
        if (smoke2.transform.position.x != smoke_endPoint2.transform.position.x)
        {
            smoke2.transform.position = Vector2.MoveTowards(smoke2.transform.position,
                smoke_endPoint2.position, Time.deltaTime * speed2);
        }
        else if (smoke2.transform.position.x == smoke_endPoint2.transform.position.x)
        {
            smoke2.transform.position = smoke_startPoint2.position;
        }
        if (smoke3.transform.position.x != smoke_endPoint3.transform.position.x)
        {
            smoke3.transform.position = Vector2.MoveTowards(smoke3.transform.position,
                smoke_endPoint3.position, Time.deltaTime * speed3);
        }
        else if (smoke3.transform.position.x == smoke_endPoint3.transform.position.x)
        {
            smoke3.transform.position = smoke_startPoint3.position;
        }
    }
}
