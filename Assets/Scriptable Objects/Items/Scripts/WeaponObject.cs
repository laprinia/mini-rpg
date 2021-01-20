using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName ="New Weapon Object", menuName = "Inventory System/Items/Weapon")]
public class WeaponObject : ItemObject
{   
    public int damage;
    public int delayToNextAttack;
    private void Awake()
    {
        itemType = ItemType.Weapon;
    }
}
