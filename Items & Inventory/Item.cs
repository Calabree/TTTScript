using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item
{
    public int id;
    public string title, description;
    public Sprite icon;
    public int price;
    public Dictionary<string, int> stats = new Dictionary<string, int>();

    public Item() { }
    public Item(int id, string title, string description, int price, Dictionary<string, int> stats) {
        this.id = id;
        this.title = title;
        this.description = description;
        this.price = price;
        this.stats = stats;
    }

    public Item(Item item)
    {
        this.id = item.id;
        this.title = item.title;
        this.description = item.description;
        this.price = item.price;
        this.stats = item.stats;
    }

    public string getDesc(Item item)
    {
        return item.description;
    }
    public string getPrice(Item item)
    {
        return item.price.ToString();
    }
    public string getTitle(Item item)
    {
        return item.title;
    }
    public int getID(Item item)
    {
        return item.id;
    }
    public bool Purchase(Item item, int isClicked)
    {
        int id = isClicked;
        switch (id)
        {
            case 1:
                return true;
                //TODO: GET CURRENT TOKEN COUNT FROM PLAYER. SUBTRACT COST FROM TOKEN COUNT. ADD TO INV. UPDATE TOKEN COUNT.
            case 2:
                //TODO: GET CURRENT TOKEN COUNT FROM PLAYER. SUBTRACT COST FROM TOKEN COUNT. ADD TO INV. UPDATE TOKEN COUNT.
                return true;
            case 3:
                //TODO: GET CURRENT TOKEN COUNT FROM PLAYER. SUBTRACT COST FROM TOKEN COUNT. ADD TO INV. UPDATE TOKEN COUNT.
                return true;
            default:
                Debug.Log("Default");
                return false;
                break;
        }
    }

}