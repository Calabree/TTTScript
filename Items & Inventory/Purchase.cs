using Firebase.Database;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Purchase:MonoBehaviour
{
    static int xprice, xid;
    static bool xbuy;
    int tokens, inv1, inv2, inv3, inv4;
    private string key;
    DatabaseReference mDatabaseRef;
    
    private void Awake()
    {
        tokens = readDatabaseToken();
    }
    public void OnMouseDown()
    {
        
        if (xbuy)
        {
            int updatedTokens = tokens - xprice;

            Debug.Log(updatedTokens);
            writeToDatabase(tokens);
                //TODO: Update user inv and Token in database
            
        }
        else
        {
            Debug.Log("can't buy");
        }
    }

    public static void setPrice(int price)
    {
        xprice = price;
    }
    public static void setBuy(bool buy)
    {
        xbuy = buy;
    }
    public static void setItemID(int id)
    {
        xid = id;
    }

    public void writeToDatabase(int token)
    {
        mDatabaseRef = FirebaseDatabase.DefaultInstance.RootReference;
        mDatabaseRef.Child("users").Child(key).Child("token").SetValueAsync(token);

    }
    public int readDatabaseToken()
    {
        Firebase.Auth.FirebaseAuth auth = Firebase.Auth.FirebaseAuth.DefaultInstance;
        Firebase.Auth.FirebaseUser cUser = auth.CurrentUser;
        key = cUser.UserId;
    
        FirebaseDatabase.DefaultInstance.GetReference("users").GetValueAsync().ContinueWith(task => {
            if (task.IsFaulted)
            {
                Debug.Log(task.Exception);
            }
            else if (task.IsCompleted)
            {
                DataSnapshot snapshot = task.Result;

                tokens = int.Parse(snapshot.Child(key).Child("token").Value.ToString());
                inv1 = int.Parse(snapshot.Child(key).Child("Inv1").Value.ToString());
                inv2 = int.Parse(snapshot.Child(key).Child("Inv2").Value.ToString());
                inv3 = int.Parse(snapshot.Child(key).Child("Inv3").Value.ToString());

                Debug.Log("Nice:" + tokens);
            }
        });
        return tokens;
    }

  
}
