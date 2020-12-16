using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Royal Waffle Potion Object", menuName = "Inventory System/Items/Royal Waffle Potion")]
public class RoyalWafflePotionObject : ItemObject
{
    public int restoreHealthValue;
    public int restoreEnergyValue;
    public void awake()
    {
        type = ItemType.RoyalWafflePotion;
    }
}
