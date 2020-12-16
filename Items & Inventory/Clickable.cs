using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Clickable : ItemDatabase
{
    public int id;
    Item item;
    Purchase purchase;
    public TextMeshPro desc, prc,ttl;
    int itemID;
    public void OnMouseDown()
    {
        item = new Item();
        //Item itemID = itemDatabase.GetItem(id);
        string description = item.getDesc(GetItem(id));
        string price = item.getPrice(GetItem(id));
        string title = item.getTitle(GetItem(id));
        int itemID = item.getID(GetItem(id));
        desc.text = description;
        prc.text = price;
        ttl.text = title;
        bool canBuy = item.Purchase(item, itemID);
        Purchase.setPrice(int.Parse(price));
        Purchase.setBuy(canBuy);

    }


}
