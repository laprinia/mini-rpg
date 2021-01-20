using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ConsumableType
{
    Luck,
    Sanity
}
[CreateAssetMenu(fileName ="New Consumable Object", menuName = "Inventory System/Items/Consumable")]
public class ConsumableObject : ItemObject
{   
    public ConsumableType consumableType;
    public int restorativePower;
  
    private void Awake()
    {
        itemType=ItemType.Consumable;
    }
}