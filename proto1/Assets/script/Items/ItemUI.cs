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

    void Start()
    {
        itemPickup = GetComponent<ItemPickup>();
        isItemAlreadyAdded = false;

    }

    // Update is called once per frame
    void Update()
    {
        if (!isItemAlreadyAdded && standItem.isItemAdded && itemPickup.isInteracting)
        {
            FillAndEnable(standItem.inner_item.name + UIContent.ITEM_ADDED);

        }
        else if ((itemPickup.isPickedUp && isItemAlreadyAdded && itemPickup.isInteracting) || 
            (!standItem.inner_item && itemPickup.isPickedUp && !isItemAlreadyAdded && itemPickup.isInteracting))
        {
            FillAndEnable(standItem.name + UIContent.INV_IS_EMPTY);
        }
        else if (!itemPickup.isInteracting && standItem.isItemAdded)
        {
            ClearAndDisable();
            isItemAlreadyAdded = true;
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
