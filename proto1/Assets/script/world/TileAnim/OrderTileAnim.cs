using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrderTileAnim : MonoBehaviour
{
    public SpriteRenderer spriteRendererPlayer;
    private GameObject player;
    private int order = 21;
    private int oldOrder = 0;
    private List<int> player_orders;
    SpriteRenderer[] renders;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        player_orders = new List<int>();
        renders = player.GetComponentsInChildren<SpriteRenderer>();
        foreach (SpriteRenderer item in renders)
        {
            player_orders.Add(item.sortingOrder);
        }

        oldOrder = spriteRendererPlayer.sortingOrder;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        //spriteRendererPlayer.sortingOrder = order;
        foreach (SpriteRenderer item in renders)
        {
            item.sortingOrder += order;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        for (int i = 0; i < renders.Length; i++)
        {
            renders[i].sortingOrder = player_orders[i];
        } 
    }
}
