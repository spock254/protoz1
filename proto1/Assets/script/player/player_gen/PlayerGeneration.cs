using System.Collections.Generic;
using UnityEngine;

public class PlayerGeneration : MonoBehaviour
{
    [Header("head")]
    public List<GameObject> player_heads;
    public GameObject head;
    [Header("head bg")]
    public List<GameObject> player_heads_bg;
    public GameObject head_bg;
    [Header("body")]
    public List<GameObject> player_body;
    public GameObject body;
    [Header("lags")]
    public List<GameObject> player_lags;
    public GameObject lags;
    [Header("hands left")]
    public List<GameObject> player_hands_left;
    public GameObject hands_left;
    [Header("hands right")]
    public List<GameObject> player_hands_right;
    public GameObject hands_right;

    private GameObject head_bg_container;
    private GameObject head_container;
    private GameObject body_conainer;
    private GameObject lags_container;
    private GameObject hands_container;

    //Colors
    public List<Color> skin_colors;
    public List<Color> hair_colors;
    public List<Color> body_colors;
    public List<Color> lags_colors;

    private int current_index;
    //Animation
    private bool up, down, left, right;
    private List<Animator> animators;

    void Awake()
    {
        animators = new List<Animator>();

        head_bg_container = GameObject.FindGameObjectWithTag("head_bg_container");
        head_container = GameObject.FindGameObjectWithTag("head_container");
        body_conainer = GameObject.FindGameObjectWithTag("body_conainer");
        lags_container = GameObject.FindGameObjectWithTag("lags_container");
        hands_container = GameObject.FindGameObjectWithTag("hands_container");


    }
    private void Start()
    {
        int index = Random.Range(0, player_heads.Count);
        int color_skin_index = Random.Range(0, skin_colors.Count);

        RandomizePlayerPart(player_heads_bg, head_bg_container, head_bg, index, color_skin_index); // head bg
        RandomizePlayerPart(player_heads, head_container, head, index, hair_colors); // head
        RandomizePlayerPart(player_body, body_conainer, body, body_colors); // body
        RandomizePlayerPart(player_lags, lags_container, lags, lags_colors); // lags
        RandomizePlayerPart(player_hands_left, hands_container, hands_left, color_skin_index); // hand left
        RandomizePlayerPart(player_hands_right, hands_container, hands_right, color_skin_index); // hand right

    }
    void Update()
    {
        float moveY = Input.GetAxisRaw("Vertical");
        float moveX = Input.GetAxisRaw("Horizontal");
        AnimController(moveX, moveY);
        AnimSet();
    }
    void RandomizePlayerPart(List<GameObject> contents,GameObject container,GameObject current_part,List<Color> colors)
    {
        Destroy(current_part);
        current_index = Random.Range(0, contents.Count);
        current_part = Instantiate(contents[current_index]);
        current_part.transform.SetParent(container.transform);
        animators.Add(current_part.GetComponent<Animator>());
        ColorRandomize(current_part, colors);
    }
    void RandomizePlayerPart(List<GameObject> contents, GameObject container, GameObject current_part, int color_index)
    {
        Destroy(current_part);
        current_index = Random.Range(0, contents.Count);
        current_part = Instantiate(contents[current_index]);
        current_part.transform.SetParent(container.transform);
        animators.Add(current_part.GetComponent<Animator>());
        ColorRandomize(current_part, skin_colors[color_index]);
    }
    void RandomizePlayerPart(List<GameObject> contents, GameObject container, GameObject current_part,int index, List<Color> colors)
    {
        Destroy(current_part);
        current_index = index;
        current_part = Instantiate(contents[current_index]);
        current_part.transform.SetParent(container.transform);
        animators.Add(current_part.GetComponent<Animator>());
        ColorRandomize(current_part, colors);
    }
    void RandomizePlayerPart(List<GameObject> contents, GameObject container, GameObject current_part, int index, int color_index)
    {
        Destroy(current_part);
        current_index = index;
        current_part = Instantiate(contents[current_index]);
        current_part.transform.SetParent(container.transform);
        animators.Add(current_part.GetComponent<Animator>());
        ColorRandomize(current_part, skin_colors[color_index]);
    }

    private void AnimController(float x, float y)
    {
        left = (x < 0) ? true : false;
        right = (x > 0) ? true : false;
        up = (y > 0) ? true : false;
        down = (y < 0) ? true : false;
    }
    private void AnimSet()
    {
        foreach (Animator animator in animators)
        {
            animator.SetBool("up", up);
            animator.SetBool("down", down);
            animator.SetBool("left", left);
            animator.SetBool("right", right);
        }
    }
    private void IdleAnim()
    {
        foreach (Animator animator in animators)
        {
            animator.SetBool("up", false);
            animator.SetBool("down", false);
            animator.SetBool("left", false);
            animator.SetBool("right", false);
        }
    }
    private void ColorRandomize(GameObject part, List<Color> colors)
    {
        part.GetComponent<SpriteRenderer>().color = colors[Random.Range(0, colors.Count)];
    }
    private void ColorRandomize(GameObject part, Color color)
    {
        part.GetComponent<SpriteRenderer>().color = color;
    }
    private void ColorRandomize(GameObject part,GameObject part2,GameObject part3, List<Color> colors)
    {
        int newColor_index = Random.Range(0, colors.Count);
        part.GetComponent<SpriteRenderer>().color = colors[newColor_index];
        part2.GetComponent<SpriteRenderer>().color = colors[newColor_index];
        part3.GetComponent<SpriteRenderer>().color = colors[newColor_index];
    }
}
