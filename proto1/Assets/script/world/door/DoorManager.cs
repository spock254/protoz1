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
    private void Update()
    {
        // TODO 
        if (Input.GetKeyDown(KeyCode.E))
        {
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
       

        if (Input.GetKeyDown(KeyCode.E) && isOutside)
        {
            player.transform.position = insideSpownPoint.position;
            InsadeFade();
            insaideCollider2D.enabled = true;
            outsaideCollider2D.enabled = false;
           // isOutside = false;
            animator.SetBool("open", true);
            Debug.Log("Entered");
        }
        else if (Input.GetKeyDown(KeyCode.E) && !isOutside)
        {
            player.transform.position = outsideSpownPoint.position;
            OutsideFade();
            insaideCollider2D.enabled = false;
            outsaideCollider2D.enabled = true;
            //isOutside = true;
            animator.SetBool("open", true);
            Debug.Log("Exit");
        }
        
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        animator.SetBool("open", false);
        Debug.Log("X");
        //isOutside = !isOutside;
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
