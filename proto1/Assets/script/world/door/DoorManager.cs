using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorManager : MonoBehaviour
{
    public List<GameObject> outsideFades;
    public List<GameObject> insidedeFades;
    public Transform outsideSpownPoint;
    public Transform insideSpownPoint;

    private Animator animator;
    public BoxCollider2D outsaideCollider2D;
    public BoxCollider2D insaideCollider2D;
    private GameObject player;

    [HideInInspector]
    public bool isOutside = true;

    private void Start()
    {
        animator = GetComponent<Animator>();
        player = GameObject.FindGameObjectWithTag("Player");
        insaideCollider2D.enabled = false;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (Input.GetKeyDown(KeyCode.E) && isOutside)
        {
            player.transform.position = insideSpownPoint.position;
            switchFade();
            insaideCollider2D.enabled = false;
            outsaideCollider2D.enabled = true;
            isOutside = false;
            animator.SetBool("open", true);
            Debug.Log("Entered");
        }
        else if (Input.GetKeyDown(KeyCode.E) && !isOutside)
        {
            player.transform.position = outsideSpownPoint.position;
            switchFade();
            insaideCollider2D.enabled = true;
            outsaideCollider2D.enabled = false;
            isOutside = true;
            animator.SetBool("open", true);
            Debug.Log("Exit");
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        animator.SetBool("open", false);
    }
    private void switchFade()
    {
        if (isOutside)
        {
            //TODO lerp fade
            foreach (GameObject fade in outsideFades)
                fade.SetActive(isOutside);
            foreach (GameObject fade in insidedeFades)
                fade.SetActive(!isOutside);
        }
        else
        {
            foreach (GameObject fade in outsideFades)
                fade.SetActive(!isOutside);
            foreach (GameObject fade in insidedeFades)
                fade.SetActive(isOutside);
        }
    }
}
