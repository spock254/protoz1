using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Interactable : MonoBehaviour
{
    public float radius = 3f;
    [HideInInspector]
    public bool isInteracting = false;   // Is this interactable currently being focused?
    Transform player;       // Reference to the player transform
    protected bool hasInteracted = false; // Have we already interacted with the object?


    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        if (player == null)
            Debug.LogError("Player is null");

    }

    protected virtual void Start() { }

    void Update()
    {

        float distance = Vector2.Distance(player.position, this.transform.position);
        if (distance <= radius)
        {
            isInteracting = true;
            Interact();
        }
        else isInteracting = false;

    }




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
