using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrderTileAnim : MonoBehaviour
{
    public SpriteRenderer spriteRendererPlayer;
    private int order = 21;
    private int oldOrder = 0;
    // Start is called before the first frame update
    void Start()
    {
        oldOrder = spriteRendererPlayer.sortingOrder;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        spriteRendererPlayer.sortingOrder = order;
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        spriteRendererPlayer.sortingOrder = oldOrder;
    }
}
