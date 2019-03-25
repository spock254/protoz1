using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorManager : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;

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
    private int sortingOrder = 0;
    private bool isInArea = false;

    private void Start()
    {
        animator = GetComponent<Animator>();
        player = GameObject.FindGameObjectWithTag("Player");
        spriteRenderer = GetComponent<SpriteRenderer>();
        sortingOrder = spriteRenderer.sortingOrder;
        insaideCollider2D.enabled = false;
    }
    private void Update()
    {
        // TODO 
        if (Input.GetKeyDown(KeyCode.Space))
        {
            //animator.Play("open_door");
            float distanceOutside = Vector2.Distance(player.transform.position, outsideSpownPoint.position);
            float distanceInside = Vector2.Distance(player.transform.position, insideSpownPoint.position);
            if (distanceOutside > distanceInside)
                isOutside = false;
            else
                isOutside = true;
        }
        
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        //if (!isInArea) isInArea = true;

        if (Input.GetKeyDown(KeyCode.Space) && isOutside)
        {
            player.transform.position = insideSpownPoint.position;
            InsadeFade();
            insaideCollider2D.enabled = true;
            outsaideCollider2D.enabled = false;
            spriteRenderer.sortingOrder = sortingOrder + 10;
            animator.Play("open_door");
            // animator.SetBool("open", true);
        }
        else if (Input.GetKeyDown(KeyCode.Space) && !isOutside)
        {
            player.transform.position = outsideSpownPoint.position;
            OutsideFade();
            insaideCollider2D.enabled = false;
            outsaideCollider2D.enabled = true;
            spriteRenderer.sortingOrder = sortingOrder;
            animator.Play("open_door");
            // animator.SetBool("open", true);
        }
        
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        //isInArea = false;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //isInArea = true;
    }
    private void InsadeFade()
    {
        foreach (GameObject fade in outsideFades)
            fade.SetActive(true);
        foreach (GameObject fade in insidedeFades)
            fade.SetActive(false);
    }
    private void OutsideFade()
    {
        foreach (GameObject fade in outsideFades)
            fade.SetActive(false);
        foreach (GameObject fade in insidedeFades)
            fade.SetActive(true);
    }
    
}
