using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Interactable : MonoBehaviour
{
    public float radius = 3f;
    //public Transform interactionTransform;
    bool isFocus = false;   // Is this interactable currently being focused?
    Transform player;       // Reference to the player transform
    bool hasInteracted = false; // Have we already interacted with the object?
    //public Collider2D playerCollider;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        if (player == null)
            Debug.LogError("Player is null");
    }

    //void Update()

    //{
    //    if (isFocus)    // If currently being focuse
    //    {
    //         float distance = Vector2.Distance(player.position, interactionTransform.position);
    //         // If we haven't already interacted and the player is close enough
    //        if (!hasInteracted && distance <= radius)
    //        {
    // Interact with the object
    //             hasInteracted = true;
    //            Interact();

    //        }
    //    }
    // }

    void Update()
    {
        float distance = Vector2.Distance(player.position, this.transform.position);
        if (distance <= radius)
        {
            Interact();
        }
    }


    //  void OnTriggerStay2D(Collider2D col)
    // {
    //      if(playerCollider == col && Input.GetKeyDown(KeyCode.E))
    // Debug.Log("IN");
    //Debug.Log(col.gameObject.name + " : " + gameObject.name + " : " + Time.time);
    //if (Input.GetKeyDown(KeyCode.E))
    //       {
    //Debug.Log("+");
    //        Interact();
  //      }
  //  }

    // This method is meant to be overwritten
    public virtual void Interact()
    {



    }
    void OnDrawGizmosSelected()
    {
    //    if (interactionTransform = null)
   //         interactionTransform = transform;
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(this.transform.position, radius);
    }
}
