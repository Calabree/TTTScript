using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Firebase.Database;
public class Tokens : MonoBehaviour
{
    [SerializeField] private TokenConverter tokenConverter;
    [SerializeField] private Pedometer pedometer;
    public TextMeshProUGUI tokenText;
    DatabaseReference mDatabaseRef;

    private string key;

    private float nextActionTime = 2.0f;
    private int tokens;

    void Awake()
    {
        tokenConverter = new TokenConverter();
        pedometer = new Pedometer();
        Firebase.Auth.FirebaseAuth auth = Firebase.Auth.FirebaseAuth.DefaultInstance;
        Firebase.Auth.FirebaseUser cUser = auth.CurrentUser;
        key = cUser.UserId;
        tokens = readDatabaseToken();

    }
    private void Update()
    {
        tokenConverter.calculateTokens(tokens);
        tokens = int.Parse(tokenConverter.getTokens().ToString());
        tokenText.text = tokenConverter.getTokens().ToString();
        if (Time.time > nextActionTime)
        {
            nextActionTime += 2;
            writeToDatabase(tokenConverter.getTokens());
        }
        pedometer.ResetSteps(); 
    }

    public void writeToDatabase(int token)
    {
        mDatabaseRef = FirebaseDatabase.DefaultInstance.RootReference;
        mDatabaseRef.Child("users").Child(key).Child("token").SetValueAsync(token);
        Debug.Log("Database Check");
        
    }

    public int readDatabaseToken()
    {
        Debug.Log("in the dataread");
        FirebaseDatabase.DefaultInstance.GetReference("users").GetValueAsync().ContinueWith(task => {
            if (task.IsFaulted)
            {
                Debug.Log(task.Exception);
            }
            else if (task.IsCompleted)
            {
                DataSnapshot snapshot = task.Result;

                tokens = int.Parse(snapshot.Child(key).Child("token").Value.ToString());
                Debug.Log("Nice:" + tokens);
            }
        });
        return tokens;
    }

}
