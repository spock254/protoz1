using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Steps : MonoBehaviour
{
    SpriteRenderer spriteRenderer;
    Color alpha;
    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        alpha = spriteRenderer.color;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        alpha.a += 0.01f;
        spriteRenderer.color = alpha;
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        alpha = spriteRenderer.color;
    }
}
