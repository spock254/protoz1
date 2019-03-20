using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGeneration : MonoBehaviour
{
    public List<GameObject> player_heads;
    public GameObject head;

    private GameObject head_container;

    int i = 0;
    void Start()
    {
        head_container = GameObject.FindGameObjectWithTag("head_container");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.M))
        {
            Destroy(head);
            head = Instantiate(player_heads[i]);
            i++;
            head.transform.SetParent(head_container.transform);
        }
    }
}
