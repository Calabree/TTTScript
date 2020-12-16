using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDatabase : MonoBehaviour
{

    public List<Item> items = new List<Item>();
    public Sprite[] allItems;
    private SpriteRenderer spriteR1, spriteR2, spriteR3;
    public GameObject Health, Energy, Waffle;
    void Start()
    {
        Sprite health= Resources.Load<Sprite>("Health");
        Sprite energy= Resources.Load<Sprite>("Energy");
        Sprite waffle = Resources.Load<Sprite>("Waffle");

        BuildItemDatabase();

        spriteR1 = Health.GetComponent<SpriteRenderer>();
        spriteR1.sprite = health;

        spriteR2 = Energy.GetComponent<SpriteRenderer>();
        spriteR2.sprite = energy;

        spriteR3 = Waffle.GetComponent<SpriteRenderer>();
        spriteR3.sprite = waffle;
    }

    public Item GetItem(int id)
    {
        return items.Find(item => item.id == id);
    }

    void BuildItemDatabase()
    {
        items = new List<Item>() {
            new Item(1,"Health Potion","It's a Health Potion what do you think it does?", 1000,
            new Dictionary<string, int>{
                {"Health", 50},
                {"Strength",0 },
                {"Magic",0 },
                {"Dex",0 },
                {"Def",0 },
                {"Resistance",0 },
                {"Speed",0 }
            }),
            new Item(2,"Energy Potion","It's a lot like redbull (Minus the wings)", 1000,
            new Dictionary<string, int>{
                {"Health", 0},
                {"Strength",0 },
                {"Magic",0 },
                {"Dex",50 },
                {"Def",0 },
                {"Resistance",0 },
                {"Speed",0 }
            }),new Item(3,"Royal Waffle","Rumor has it that it buffs your stregnth, I'm pretty sure it's just an Eg go", 3000,
            new Dictionary<string, int>{
                {"Health", 0},
                {"Strength",15 },
                {"Magic",0 },
                {"Dex",0 },
                {"Def",0 },
                {"Resistance",0 },
                {"Speed",0 }
            }),
        };
    }

   
}
