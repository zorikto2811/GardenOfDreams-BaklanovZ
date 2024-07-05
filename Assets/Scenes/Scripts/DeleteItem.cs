using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DeleteItem : MonoBehaviour, IPointerClickHandler
{
    public int index;
    public InventoryManager inventoryManager;
    public GameObject deleteButton;
    public Transform Handler;
    public GameObject currentWeapon;

    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Right)
        {
            deleteButton.SetActive(true);
        }
    }

    public void Delete()
    {
        if (inventoryManager.slots[index].amount != 0)
        {
            inventoryManager.slots[index].amount--;
            Destroy(Handler.GetChild(0).gameObject);
            currentWeapon = Instantiate(inventoryManager.slots[index].item.itemPrefab, Handler.position, Quaternion.identity);
            currentWeapon.transform.parent = Handler;
            currentWeapon.transform.localScale = Vector3.one;
            if (inventoryManager.slots[index].amount > 1)
            {
                inventoryManager.slots[index].itemAmountText.text = inventoryManager.slots[index].amount.ToString();
            }
            else
            {
                inventoryManager.slots[index].itemAmountText.text = null;
            }
        }
        else
        {
            inventoryManager.slots[index].DeleteIcon();
            deleteButton.SetActive(false);
        }
    }
}
