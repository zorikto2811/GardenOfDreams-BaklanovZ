using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour
{
    public ItemScriptableObject item;
    public int amount;
    public bool isEmpty = true;
    public GameObject icon;
    public Text itemAmountText;

    private void Awake()
    {
        icon = transform.GetChild(0).gameObject;
        itemAmountText = transform.GetChild(1).GetComponent<Text>();
    }

    public void SetIcon(Sprite iconSprite)
    {
        icon.GetComponent<Image>().color = new Color(1, 1, 1);
        icon.GetComponent<Image>().sprite = iconSprite;
    }

    public void DeleteIcon()
    {
        icon.GetComponent<Image>().sprite = null;
        icon.GetComponent<Image>().color = new Color(1,1,1,0);
    }
}
