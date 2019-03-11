using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnvDescription : MonoBehaviour
{
    Text envDescription;
    Item item;
    // Start is called before the first frame update
    void Start()
    {
        envDescription = GameObject.FindGameObjectWithTag("EnvDescription").GetComponent<Text>();
        if (!envDescription) Debug.Log("EnvDescription game obj with this tag has not been found");
        else envDescription.text = "";

        item = this.GetComponent<ItemPickup>().item;
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        envDescription.text = item.name;
    }
    void OnTriggerExit2D(Collider2D col)
    {
        envDescription.text = "";
    }
}
