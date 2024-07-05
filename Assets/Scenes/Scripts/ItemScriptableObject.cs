using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ItemType { Default,Food, Weapon}
public class ItemScriptableObject : ScriptableObject
{
    public ItemType itemType;
    public string itemName;
    public int maxAmount;
    public Sprite iconSprite;
    public GameObject itemPrefab;
}
