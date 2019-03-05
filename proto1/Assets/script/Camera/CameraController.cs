using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    public Vector2 camPosition = Vector2.zero;
    public Transform target;

    public float smoothX = 0.3f;
    public float smoothY = 0.3f;

    public float offsetX = 10;
    public float offsetY = 10;

    private void FixedUpdate()
    {
        camPosition = new Vector2
            (
                  Mathf.SmoothStep(transform.position.x, target.transform.position.y, smoothX),
                  Mathf.SmoothStep(transform.position.x, target.transform.position.y, smoothY)
            );
    }
    private void LateUpdate()
    {
        //transform.position = camPosition;
    }
}
