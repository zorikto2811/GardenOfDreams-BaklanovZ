using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class InventoryManager : MonoBehaviour
{
    public GameObject UIPanel;
    public Transform inventoryPanel;
    public List<InventorySlot> slots = new List<InventorySlot>();

    private void Awake()
    {
        UIPanel.SetActive(true);
    }
    private void Start()
    {
        for (int i = 0; i < inventoryPanel.childCount; i++)
        {
            if (inventoryPanel.GetChild(i).GetComponent<InventorySlot>() != null)
            {
                slots.Add(inventoryPanel.GetChild(i).GetComponent<InventorySlot>());
            }
            inventoryPanel.transform.GetChild(i).GetComponent<DeleteItem>().index = i;
        }
        UIPanel.SetActive(false);
    }

    public void OpenInventory()
    {
        UIPanel.SetActive(true);
    }

    public void CloseInventory()
    {
        UIPanel.SetActive(false);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Item") && collision.collider.GetComponent<Item>().isArmed == false)
        {
            AddItem(collision.collider.GetComponent<Item>().item, collision.collider.GetComponent<Item>().amount);
            Destroy(collision.collider.gameObject);
            collision.collider.GetComponent<Item>().isArmed = true;
        }
    }
    private void AddItem(ItemScriptableObject _item, int _amount)
    {
        foreach (InventorySlot slot in slots)
        {
            if (slot.item == _item)
            {
                if (slot.amount + _amount <= _item.maxAmount)
                {
                    slot.amount += _amount;
                    if (slot.amount > 1)
                    {
                        slot.itemAmountText.text = slot.amount.ToString();
                    }
                    else
                    {
                        slot.itemAmountText.text = null;
                    }
                    return;
                }
                break;
            }
        }
        foreach (InventorySlot slot in slots)
        {
            if (slot.isEmpty)
            {
                slot.item = _item;
                slot.amount = _amount;
                slot.SetIcon(_item.iconSprite);
                slot.itemAmountText.text = _amount.ToString();
                break;
            }
        }
    }
}
