using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerThoughts : MonoBehaviour
{
    private Transform playerTransform;
    public Vector3 playerThoughtsPosition;

    private Image image;
    [SerializeField]
    private Text text;
    private bool isOpend = false;


    void Start()
    {
        image = GetComponent<Image>();
        playerTransform = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        ThoughtsSwitch(false);
    }

    void Update()
    {

        if (Input.GetKeyDown(KeyCode.F))
        {
            StartCoroutine(EnableAndWaitFor());
        }
    }

    void FixedUpdate()
    {

         transform.position = new Vector3(playerTransform.position.x + playerThoughtsPosition.x, 
             playerTransform.position.y + playerThoughtsPosition.y, 
             playerTransform.position.z + playerThoughtsPosition.z);


    }
    private void ThoughtsSwitch(bool on_off)
    {
        image.enabled = on_off;
        text.enabled = on_off;
    }
    IEnumerator EnableAndWaitFor()
    {
        ThoughtsSwitch(true);
        yield return new WaitForSeconds(5);
        ThoughtsSwitch(false);
    }
}
