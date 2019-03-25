using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Steps : MonoBehaviour
{
    SpriteRenderer spriteRenderer;
    Color alpha;
    float random_alpha;
    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        alpha = spriteRenderer.color;
        random_alpha = Random.Range(0.01f, 0.03f);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag.Equals("steps"))
        {
            alpha.a += random_alpha;
            spriteRenderer.color = alpha;
        }
        
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag.Equals("steps"))
            alpha = spriteRenderer.color;
    }
}
