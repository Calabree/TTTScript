using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Energy Potion Object", menuName = "Inventory System/Items/Energy Potion")]
public class EnergyPotionObject : ItemObject
{
    public int restoreEnergyValue;
    public void awake()
    {
        type = ItemType.EnergyPotion;
    }
}
