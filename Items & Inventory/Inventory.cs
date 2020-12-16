using System.Collections;
using System.Collections.Generic;
using Firebase.Database;
using UnityEngine;
using System.Linq;
using System.Threading;
using System;

public class Inventory : MonoBehaviour
{
    string key, email;
    int[] inv;
    Dictionary<string, object> dictUser;
    bool isHealthy;
    private bool hasHealthPotion;
    private bool hasEnergyPotion;
    private bool hasWaffle;
    int invSlot;

    private SpriteRenderer spriteR1, spriteR2, spriteR3;
    public GameObject Health, Energy, Waffle;
    public Sprite health, energy, waffle;

    private void Awake()
    {        
        StartCoroutine(waiter());
    }

    IEnumerator waiter()
    {
        Firebase.Auth.FirebaseAuth auth = Firebase.Auth.FirebaseAuth.DefaultInstance;
        Firebase.Auth.FirebaseUser cUser = auth.CurrentUser;
        key = cUser.UserId;
        health = Resources.Load<Sprite>("Health");
        energy = Resources.Load<Sprite>("Energy");
        waffle = Resources.Load<Sprite>("Waffle");
        readDatabaseInv();
    
        yield return new WaitForSecondsRealtime(.1f);
        InventoryUpdater(hasHealthPotion, hasEnergyPotion, hasWaffle);
    }

    public string readDatabaseInv()
    {
        Firebase.Database.FirebaseDatabase dbInstance = Firebase.Database.FirebaseDatabase.DefaultInstance;
        dbInstance.GetReference("users").GetValueAsync().ContinueWith(task => {
            if (task.IsFaulted)
            {
                // Handle the error...
            }
            else if (task.IsCompleted)
            {
                DataSnapshot snapshot = task.Result;
                email = snapshot.Child(key).Child("email").Value.ToString();
                foreach (DataSnapshot user in snapshot.Children)
                {
                    
                    dictUser = (Dictionary<string, object>)user.Value;
                    if (dictUser["email"].Equals(email))
                    {
                        if (dictUser["Inv1"] != null)
                        {
                            Debug.Log("Email worked!");
                            switch (dictUser["Inv1"].ToString())
                            {
                                case "1":
                                    hasHealthPotion = true;
                                    break;
                                case "2":
                                    hasEnergyPotion = true;  
                                    break;
                                case "3":
                                    hasWaffle = true;
                                    break;
                                default:
                                    Debug.Log("user has no item");
                                    break;
                            }
                            switch (dictUser["Inv2"].ToString())
                            {
                                case "1":
                                    hasHealthPotion = true;
                                    break;
                                case "2":
                                    hasEnergyPotion = true;
                                    break;
                                case "3":
                                    hasWaffle = true;
                                    break;
                                default:
                                    Debug.Log("user has no item");
                                    break;
                            }
                            switch (dictUser["Inv3"].ToString())
                            {
                                case "1":
                                    hasHealthPotion = true;
                                    break;
                                case "2":
                                    hasEnergyPotion = true;
                                    break;
                                case "3":
                                    hasWaffle = true;
                                    break;
                                default:
                                    Debug.Log("user has no item");
                                    break;
                            }

                        }
                        
                    }
                }
            }
        });
        return email;
    }

    public void InventoryUpdater(bool healthPotion, bool energyPotion, bool waffles)
    {
        try
        {
            if (healthPotion)
            {
                spriteR1 = Health.GetComponent<SpriteRenderer>();
                spriteR1.sprite = health;
            }
            if (energyPotion)
            {
                spriteR2 = Energy.GetComponent<SpriteRenderer>();
                spriteR2.sprite = energy;
            }
            if (waffles)
            {
                spriteR3 = Waffle.GetComponent<SpriteRenderer>();
                spriteR3.sprite = waffle;
            }
        }catch(NullReferenceException e)
        {
            Debug.Log("NullReferenceException");
        }
    }

}