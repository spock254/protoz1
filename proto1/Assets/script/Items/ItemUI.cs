using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemUI : MonoBehaviour
{
    public Text dialog_text;
    public GameObject dialog_window;
    public StandItem standItem;
    public Image image;

    private ItemPickup itemPickup;

    private bool isItemAlreadyAdded = false;

    [HideInInspector]
    public bool isOpening = false;

    void Start()
    {
        itemPickup = GetComponent<ItemPickup>();
        isItemAlreadyAdded = false;

    }


    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Player" )
        {
            
            if (standItem.isItemAdded && !isItemAlreadyAdded && standItem.inner_item != null)
            {
                    FillAndEnable(standItem.inner_item.name + UIContent.ITEM_ADDED);
                isOpening = true;
            }
            else if (!standItem.isItemAdded  && standItem.inner_item != null)
            {
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    FillAndEnable(UIContent.NO_SPACE_IN_INV);
                    isItemAlreadyAdded = false;
                    isOpening = true;
                }
            }
            else if (!standItem.isItemAdded && !isItemAlreadyAdded && standItem.inner_item == null)
            {
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    FillAndEnable(standItem.name + UIContent.INV_IS_EMPTY);
                    isOpening = true;
                }
                    
            }
            else if (isItemAlreadyAdded)
            {
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    isOpening = true;
                    FillAndEnable(standItem.name + UIContent.INV_IS_EMPTY);
                }
                    
            }
            
            
        }
        
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            ClearAndDisable();
            isItemAlreadyAdded = true;
            isOpening = false;
        }
    }
    private void FillAndEnable(string content)
    {
        dialog_window.SetActive(true);
        image.sprite = standItem.icon;
        dialog_text.text = content;
    }
    private void ClearAndDisable()
    {
        dialog_text.text = "";
        image.sprite = null;
        dialog_window.SetActive(false);
    }
}
