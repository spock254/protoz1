using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovements : MonoBehaviour
{
    private Rigidbody2D rigidbody2D;
    public float curSpeed = 10;
    public static bool isPlayerInputEnable = true;
    // Start is called before the first frame update
    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(isPlayerInputEnable)
            rigidbody2D.velocity = new Vector2(Mathf.Lerp(0, Input.GetAxisRaw("Horizontal") * curSpeed, 0.8f),
                                                Mathf.Lerp(0, Input.GetAxisRaw("Vertical") * curSpeed, 0.8f));
    }
}
